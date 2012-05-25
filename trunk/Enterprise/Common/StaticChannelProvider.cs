﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Enterprise.Common
{
    /// <summary>
    /// Implementation of <see cref="IChannelProvider"/> that provides
    /// channel factories based on a single statically defined primary endpoint
    /// and a single statically defined failover endpoint.
    /// </summary>
    /// <remarks>
    /// This class is safe for use by multiple threads.
    /// </remarks>
    internal class StaticChannelProvider : IChannelProvider
    {
        #region Node class

		/// <summary>
		/// Represents a remote endpoint URI.
		/// </summary>
        class Node
        {
            private readonly Uri _url;
            private DateTime _blackOutExpiry;

            public Node(string url)
            {
                _url = new Uri(url);
                _blackOutExpiry = DateTime.MinValue;
            }

            public Uri Url
            {
                get { return _url; }
            }

			/// <summary>
			/// Gets a value indicating whether the node is currently marked as offline.
			/// </summary>
            public bool IsBlackedOut
            {
                get { return _blackOutExpiry > DateTime.Now; }
            }

			/// <summary>
			/// Marks the node as offline for the specified timeout period.
			/// No further attempt to contact the node will be made until the offline timeout expires.
			/// </summary>
			/// <param name="timeout"></param>
            public void Blackout(TimeSpan timeout)
            {
                _blackOutExpiry = DateTime.Now + timeout;
            }
        }

        #endregion

		#region ChannelInfo class

		/// <summary>
		/// Captures additional identifying information about a channel.
		/// </summary>
		class ChannelInfo : IExtension<IContextChannel>
		{
			public ChannelInfo(Type serviceContract, ChannelCredentials credentials)
			{
				this.ServiceContract = serviceContract;
				this.Credentials = credentials;
			}

			/// <summary>
			/// Gets the service contract on which the channel is based.
			/// </summary>
			public Type ServiceContract { get; private set; }

			/// <summary>
			/// Gets the credentials that were used to authenticate the channel, or null if no authentication was required.
			/// </summary>
			public ChannelCredentials Credentials { get; private set; }


			void IExtension<IContextChannel>.Attach(IContextChannel owner)
			{
				// do nothing
			}

			void IExtension<IContextChannel>.Detach(IContextChannel owner)
			{
				// do nothing
			}
		}

		#endregion

        private readonly TimeSpan _blackoutPeriod = TimeSpan.FromSeconds(30);
        private readonly RemoteServiceProviderArgs _args;
        private readonly List<Node> _nodes = new List<Node>();

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="args"></param>
        public StaticChannelProvider(RemoteServiceProviderArgs args)
        {
            _args = args;

            // add a node for each URL, ensuring that the primary is the first entry in the list
            _nodes.Add(new Node(_args.BaseUrl));
            if (!string.IsNullOrEmpty(_args.FailoverBaseUrl))
            {
                _nodes.Add(new Node(_args.FailoverBaseUrl));
            }
		}

		#region IChannelProvider

		/// <summary>
    	/// Gets the primary channel factory for the specified service contract.
    	/// </summary>
		public IClientChannel GetPrimary(Type serviceContract, ChannelCredentials credentials)
        {
			// if there were no live nodes in the list, 
			// best thing we can do is return the primary Uri
			var factory = GetFirstLiveChannelFactory(serviceContract) ?? CreateChannelFactory(serviceContract, new Uri(_args.BaseUrl));

			return CreateChannel(serviceContract, factory, credentials);
		}

    	/// <summary>
    	/// Attempts to obtain an alternate channel factory for the specified service
    	/// contract, in the event that the primary channel endpoint is unreachable.
    	/// </summary>
		public IClientChannel GetFailover(IClientChannel failedChannel)
        {
			var failedEndpoint = failedChannel.RemoteAddress;
    		var channelInfo = failedChannel.Extensions.Find<ChannelInfo>();
    		var serviceContract = channelInfo.ServiceContract;

    		// don't allow more than one thread to update the _nodes list at once
			lock (_nodes)
    		{
				// find the failed node and marked it as blacked out
				var failedNode = CollectionUtils.SelectFirst(_nodes, n => Equals(failedEndpoint.Uri, GetFullUri(serviceContract, n.Url)));
				failedNode.Blackout(_blackoutPeriod);
			}

            // get the first live node
            var factory = GetFirstLiveChannelFactory(serviceContract);

			// if no live nodes, can't create a channel
            if (factory == null)
                return null;

			// create channel
			return CreateChannel(serviceContract, factory, channelInfo.Credentials);
		}

		#endregion

		#region Helpers

		private ChannelFactory GetFirstLiveChannelFactory(Type serviceContract)
        {
			// find the first non-blacked out node in the list
			var node = CollectionUtils.SelectFirst(_nodes, n => !n.IsBlackedOut);

            return node == null ? null : CreateChannelFactory(serviceContract, node.Url);
        }

        private ChannelFactory CreateChannelFactory(Type serviceContract, Uri baseUri)
        {
            var uri = GetFullUri(serviceContract, baseUri);
            var channelFactoryClass = typeof(ChannelFactory<>).MakeGenericType(new [] { serviceContract });
            return _args.Configuration.ConfigureChannelFactory(
                new ServiceChannelConfigurationArgs(channelFactoryClass,
                                                    uri,
                                                    AuthenticationAttribute.IsAuthenticationRequired(serviceContract),
                                                    _args.MaxReceivedMessageSize,
                                                    _args.CertificateValidationMode,
                                                    _args.RevocationMode));
        }

        private static Uri GetFullUri(Type serviceContract, Uri baseUri)
        {
            return new Uri(baseUri, serviceContract.FullName);
		}

		/// <summary>
		/// Creates a channel for the specified contract, using the specified factory.
		/// Note that this method modifies the factory, therefore it cannot be re-used!
		/// </summary>
		/// <param name="serviceContract"></param>
		/// <param name="factory"></param>
		/// <param name="credentials"></param>
		/// <returns></returns>
		private static IClientChannel CreateChannel(Type serviceContract, ChannelFactory factory, ChannelCredentials credentials)
		{
			var authenticationRequired = AuthenticationAttribute.IsAuthenticationRequired(serviceContract);
			if (authenticationRequired)
			{
				factory.Credentials.UserName.UserName = credentials.UserName;
				factory.Credentials.UserName.Password = credentials.Password;
			}

			// invoke the CreateChannel method on the factory
			var createChannelMethod = factory.GetType().GetMethod("CreateChannel", Type.EmptyTypes);
			var channel = (IClientChannel)createChannelMethod.Invoke(factory, null);
			Platform.Log(LogLevel.Debug, "Created service channel instance for service {0}, authenticationRequired={1}, endpoint={2}",
						 serviceContract.Name, authenticationRequired, factory.Endpoint.Address.Uri);

			// add some identifying information to the channel, in case we are asked to obtain a failover channel
			channel.Extensions.Add(new ChannelInfo(serviceContract, credentials));

			return channel;
		}

		#endregion
	}
}
