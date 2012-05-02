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
using System.ServiceModel;
using System.ServiceModel.Security;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using System.Security.Cryptography.X509Certificates;
using Castle.DynamicProxy;
using Castle.Core.Interceptor;
using System.Collections.Generic;

namespace ClearCanvas.Enterprise.Common
{
	#region RemoteServiceProviderArgs class

	/// <summary>
	/// Encapsulates options that confgiure a <see cref="RemoteServiceProviderBase{T}"/>.
	/// </summary>
	public class RemoteServiceProviderArgs
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="configurationClassName"></param>
		/// <param name="maxReceivedMessageSize"></param>
		/// <param name="certificateValidationMode"></param>
		/// <param name="revocationMode"></param>
		[Obsolete("Use another constructor overload")]
		public RemoteServiceProviderArgs(
			string baseUrl,
			string configurationClassName,
			int maxReceivedMessageSize,
			X509CertificateValidationMode certificateValidationMode,
			X509RevocationMode revocationMode)
			: this(baseUrl, null, configurationClassName, maxReceivedMessageSize, certificateValidationMode,
				revocationMode, null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="failoverBaseUrl"></param>
		/// <param name="configurationClassName"></param>
		/// <param name="maxReceivedMessageSize"></param>
		/// <param name="certificateValidationMode"></param>
		/// <param name="revocationMode"></param>
		public RemoteServiceProviderArgs(
			string baseUrl,
			string failoverBaseUrl,
			string configurationClassName,
			int maxReceivedMessageSize,
			X509CertificateValidationMode certificateValidationMode,
			X509RevocationMode revocationMode)
			: this(baseUrl, failoverBaseUrl, configurationClassName, maxReceivedMessageSize, certificateValidationMode,
				revocationMode, null)
		{
		}



		/// <summary>
		/// Constructor
		/// </summary>
		public RemoteServiceProviderArgs(
			string baseUrl,
			string failoverBaseUrl,
			string configurationClassName,
			int maxReceivedMessageSize,
			X509CertificateValidationMode certificateValidationMode,
			X509RevocationMode revocationMode,
			string credentialsProviderClassName)
		{
			BaseUrl = baseUrl;
			FailoverBaseUrl = failoverBaseUrl;
			Configuration = InstantiateClass<IServiceChannelConfiguration>(configurationClassName);
			MaxReceivedMessageSize = maxReceivedMessageSize;
			CertificateValidationMode = certificateValidationMode;
			RevocationMode = revocationMode;
			UserCredentialsProvider = string.IsNullOrEmpty(credentialsProviderClassName) ? null :
				InstantiateClass<IUserCredentialsProvider>(credentialsProviderClassName);
		}

		/// <summary>
		/// Base URL shared by all services in the service layer.
		/// </summary>
		public string BaseUrl { get; set; }

		/// <summary>
		/// Failover base URL shared by all services in the service layer.
		/// </summary>
		public string FailoverBaseUrl { get; set; }

		/// <summary>
		/// Configuration that is responsible for configuring the service binding/endpoint.
		/// </summary>
		public IServiceChannelConfiguration Configuration { get; set; }

		/// <summary>
		/// Maximum size in bytes of message received by the service client.
		/// </summary>
		public int MaxReceivedMessageSize { get; set; }

		/// <summary>
		/// Certificate validation mode.
		/// </summary>
		public X509CertificateValidationMode CertificateValidationMode { get; set; }

		/// <summary>
		/// Certificate revocation mode.
		/// </summary>
		public X509RevocationMode RevocationMode { get; set; }

		/// <summary>
		/// Gets or sets an <see cref="IUserCredentialsProvider"/>.
		/// May be null if user credentials are not relevant.
		/// </summary>
		public IUserCredentialsProvider UserCredentialsProvider { get; set; }

		private static T InstantiateClass<T>(string className)
		{
			try
			{
				var type = Type.GetType(className, true);
				return (T)Activator.CreateInstance(type);
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Cannot instantiate class {0}", className);
				throw;
			}
		}
	}

	#endregion


	/// <summary>
	/// Abstract base class for remote service provider extensions.
	/// </summary>
	public abstract class RemoteServiceProviderBase : IServiceProvider
	{
		#region DisposableInterceptor

		/// <summary>
		/// Interceptor that ensure <see cref="IDisposable"/> is honoured.
		/// </summary>
		internal class DisposableInterceptor : IInterceptor
		{
			public void Intercept(IInvocation invocation)
			{
				// if not invoking IDisposable.Dispose(), we can just Proceed and return
				if (!InvocationMethodIsDispose(invocation))
				{
					// proceed normally
					invocation.Proceed();
					return;
				}

				var channel = GetInvocationTarget(invocation) as IClientChannel;
				try
				{
					// to propertly clean up the channel, we should call Close() first,
					// and then Dispose(), which may be redundant, but might as well be strict
					// do not proceed along the interceptor chain
					if(channel != null)
					{
						channel.Close();
						channel.Dispose();
					}
				}
				catch (Exception e)
				{
					Platform.Log(LogLevel.Error, e,
						"Exception generated when attempting to close channel with URI {0}",
						channel.RemoteAddress.Uri);

					channel.Abort();
				}
			}

			private static bool InvocationMethodIsDispose(IInvocation invocation)
			{
				return invocation.Method.DeclaringType == typeof(IDisposable)
					&& invocation.Method.Name == "Dispose";
			}

			private static object GetInvocationTarget(IInvocation invocation)
			{
				var target = invocation.InvocationTarget;

				// this is odd - it is not clear whether InvocationTarget is the proxy or the target
				// DP seems to do different things under different circumstances, probably due to bugs
				// we do the safe thing and check if we need to access the inner object
				if ((target is IProxyTargetAccessor))
				{
					return ((IProxyTargetAccessor)target).DynProxyGetTarget();
				}

				// just return the target
				return target;
			}
		}

		#endregion

		private readonly ProxyGenerator _proxyGenerator;
		private readonly IChannelProvider _channelProvider;
		private readonly IUserCredentialsProvider _userCredentialsProvider;
		private List<IInterceptor> _interceptors;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="args"></param>
		protected RemoteServiceProviderBase(RemoteServiceProviderArgs args)
			: this(new StaticChannelProvider(args), args.UserCredentialsProvider)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="channelProvider"></param>
		/// <param name="userCredentialsProvider"></param>
		protected RemoteServiceProviderBase(IChannelProvider channelProvider, IUserCredentialsProvider userCredentialsProvider)
		{
			_channelProvider = channelProvider;
			_userCredentialsProvider = userCredentialsProvider;
			_proxyGenerator = new ProxyGenerator();
		}

		#region IServiceProvider

		public object GetService(Type serviceContract)
		{
			// check if the service is provided by this provider
			if (CanProvideService(serviceContract))
				return null;

			// create the channel
			var authenticationRequired = AuthenticationAttribute.IsAuthenticationRequired(serviceContract);
			var credentials = authenticationRequired
			                  	? new ChannelCredentials {UserName = this.UserName, Password = this.Password}
			                  	: null;
			var channel = _channelProvider.GetPrimary(serviceContract, credentials);

			// create an AOP proxy around the channel, and return that
			return CreateChannelProxy(serviceContract, channel);
		}

		#endregion

		#region Protected API

		/// <summary>
		/// Gets a value indicating whether this service provider provides the specified service.
		/// </summary>
		protected abstract bool CanProvideService(Type serviceType);

		/// <summary>
		/// Applies AOP interceptors to the proxy.
		/// </summary>
		/// <remarks>
		/// Override this method to customize which interceptors are applied to the
		/// proxy by adding/removing or inserting into the specified list.
		/// The order of interceptors is significant.  The first entry
		/// in the list is the outermost, and the last entry in the list is the 
		/// innermost.
		/// </remarks>
		/// <param name="interceptors"></param>
		protected virtual void ApplyInterceptors(IList<IInterceptor> interceptors)
		{
			// this must be added as the outer-most interceptor
			// it is basically a hack to prevent the interception chain from acting on a call to Dispose(),
			// because Dispose() is not a service operation
			interceptors.Add(new DisposableInterceptor());

			if (Caching.Cache.IsSupported())
			{
				// add response-caching client-side advice
				interceptors.Add(new ResponseCachingClientAdvice());
			}

			// add fail-over advice at the end of the list, closest the target call
			//TODO: can we avoid adding this advice if no failover is defined?
			interceptors.Add(new FailoverClientAdvice(this));
		}

		/// <summary>
		/// Gets the user name to pass as a credential to the service.
		/// </summary>
		protected virtual string UserName
		{
			get { return _userCredentialsProvider == null ? "" : _userCredentialsProvider.UserName; }
		}

		/// <summary>
		/// Gets the password to pass as a credential to the service.
		/// </summary>
		protected virtual string Password
		{
			get { return _userCredentialsProvider == null ? "" : _userCredentialsProvider.SessionTokenId; }
		}

		/// <summary>
		/// Attempts to get a failover channel for the specified failed channel.
		/// Note that a raw channel is returned, not a decorated proxy.
		/// </summary>
		/// <param name="failedChannel"></param>
		/// <returns></returns>
		protected internal IClientChannel GetFailoverChannel(IClientChannel failedChannel)
		{
			return _channelProvider.GetFailover(failedChannel);
		}

		#endregion

		#region Helpers

		private object CreateChannelProxy(Type serviceContract, IClientChannel channel)
		{
			// ensure we only access the proxy generator in a thread-safe manner
			lock(_proxyGenerator)
			{
				// get list of interceptors if not yet created
				if (_interceptors == null)
				{
					_interceptors = new List<IInterceptor>();
					ApplyInterceptors(_interceptors);
				}

				var options = new ProxyGenerationOptions();

				// create and return proxy
				// note: _proxyGenerator does internal caching based on service contract
				// so subsequent calls based on the same contract will be fast
				// note: important to proxy IDisposable too, otherwise channels can't get disposed!!!
				return _proxyGenerator.CreateInterfaceProxyWithTarget(
					serviceContract,
					new[] { serviceContract, typeof(IDisposable) },
					channel,
					options,
					_interceptors.ToArray());
			}
		}

		#endregion
	}

	/// <summary>
	/// Abstract base class for remote service provider extensions.
	/// </summary>
	/// <typeparam name="TServiceLayerAttribute">Attribute that identifiers the service layer to which a service belongs.</typeparam>
	public abstract class RemoteServiceProviderBase<TServiceLayerAttribute> : RemoteServiceProviderBase
		where TServiceLayerAttribute : Attribute
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="args"></param>
		protected RemoteServiceProviderBase(RemoteServiceProviderArgs args)
			: base(args)
		{
		}

		#region Protected API

		/// <summary>
		/// Gets a value indicating whether this service provider provides the specified service.
		/// </summary>
		/// <remarks>
		/// The default implementation is based on the service contract being marked with the <see cref="TServiceLayerAttribute"/>
		/// attribute.  Override this method to customize which services are provided by this provider.
		/// </remarks>
		/// <param name="serviceType"></param>
		/// <returns></returns>
		protected override bool CanProvideService(Type serviceType)
		{
			return !AttributeUtils.HasAttribute<TServiceLayerAttribute>(serviceType);
		}

		#endregion
	}
}
