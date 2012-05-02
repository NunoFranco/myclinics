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
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;
using System.ServiceModel.Dispatcher;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Enterprise.Core.ServiceModel
{
    /// <summary>
    /// Implementation of <see cref="IServiceBehaviour"/> that is used to customize a WCF
    /// service host such that it obtains instances of service implementations from
    /// a <see cref="IServiceFactory"/>.
    /// </summary>
    /// <remarks>
    /// Based on code found here: http://orand.blogspot.com/2006/10/wcf-service-dependency-injection.html
    /// </remarks>
    class ServiceFactoryInjectionServiceBehavior : IServiceBehavior
    {
        #region IInstanceProvider implementation

        class InstanceProvider : IInstanceProvider
        {
            private Type _serviceContract;
            private IServiceFactory _serviceFactory;

            internal InstanceProvider(Type serviceContract, IServiceFactory serviceFactory)
            {
                _serviceContract = serviceContract;
                _serviceFactory = serviceFactory;
            }

            #region IInstanceProvider Members

            public object GetInstance(InstanceContext instanceContext, Message message)
            {
                return _serviceFactory.GetService(_serviceContract);
            }

            public object GetInstance(InstanceContext instanceContext)
            {
                return GetInstance(instanceContext, null);
            }

            public void ReleaseInstance(InstanceContext instanceContext, object instance)
            {
            }

            #endregion
        }

        #endregion

        private Type _serviceContract;
        private IServiceFactory _serviceManager;

        /// <summary>
        /// Constructs an instance of the service behaviour that obtains instances of the
        /// specified service contract from the specified service factory.
        /// </summary>
        /// <param name="serviceContract"></param>
        /// <param name="serviceManager"></param>
        public ServiceFactoryInjectionServiceBehavior(Type serviceContract, IServiceFactory serviceManager)
        {
            _serviceContract = serviceContract;
            _serviceManager = serviceManager;
        }


		#region IServiceBehavior Members

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider =
                            new InstanceProvider(_serviceContract, _serviceManager);
                    }
                }
            }
        }

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		#endregion
	}
}