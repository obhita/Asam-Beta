#region License
// Open Behavioral Health Information Technology Architecture (OBHITA.org)
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the <organization> nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Agatha.Common.InversionOfControl;
using Agatha.ServiceLayer;
using Agatha.ServiceLayer.Conventions;
using Asam.Ppc.Infrastructure.Extensions;
using Asam.Ppc.Infrastructure.Services;
using AutoMapper;
using AutoMapper.Mappers;
using NLog;
using Pillar.Common.Bootstrapper;
using Pillar.Common.Configuration;
using Pillar.Common.Cryptography;
using Pillar.Domain.Event;
using StructureMap;
using IContainer = StructureMap.IContainer;
using PillarIoC = Pillar.Common.InversionOfControl.IoC;

namespace Asam.Ppc.Bootstrapper
{
    /// <summary>
    /// Defines the bootstrapper process needs to run.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger ();

        /// <summary>
        /// Initializes the specified app state.
        /// </summary>
        public virtual void Run ()
        {
            Logger.Info("Initializing StructureMap IoC Container");
            var appContainer = CreateAndConfigureApplicationDiContainer ();

            //Need to configure AutoMapper before it is used so do it right away.
            Logger.Info("Initializing AutoMapper");
            ConfigureAutoMapper ( appContainer );

            Logger.Info("Initializing Pillar IoC");
            ConfigurePillarIoC(appContainer);

            Logger.Info("Initializing Agatha");
            ConfigureAgatha ( appContainer );

            Logger.Info("Running Bootstrapper Tasks");
            RunBootstrapperTasks ( appContainer );

            Logger.Debug ( appContainer.WhatDoIHave () );
        }

        /// <summary>
        /// Configures the auto mapper.
        /// </summary>
        /// <param name="appContainer">The app container.</param>
        protected virtual void ConfigureAutoMapper ( IContainer appContainer )
        {
            var originalMapperFunction = MapperRegistry.AllMappers;
            MapperRegistry.AllMappers = () =>
                                            {
                                                var mappers = ( originalMapperFunction.Invoke () as IObjectMapper[] ).ToList ();
                                                var objectMappers = appContainer.GetAllInstances<IObjectMapper> ();
                                                mappers.AddRange ( objectMappers );
                                                return mappers.ToArray ();
                                            };
        }

        /// <summary>
        /// Creates the and configure application di container.
        /// </summary>
        /// <returns>A StructureMap Container.</returns>
        protected virtual IContainer CreateAndConfigureApplicationDiContainer()
        {
            // App Settings Configuration
            ObjectFactory.Configure(c => c.For<IConfigurationPropertiesProvider>().Singleton().Use<AppSettingsConfiguration>());

            // AES Encryption Utility
            ObjectFactory.Configure(c => c.For<IEncryptionUtility>().Use<AesEncryptionUtility>());

            //// RavenDb
            //ObjectFactory.Configure(c => c.ForSingletonOf<IDocumentStore>().Use(new DocumentStore()));
            //ObjectFactory.Configure(c =>c.For<IRavenConfiguration>().Singleton().Use(context => null));
            //ObjectFactory.Configure(c =>c.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<RavenUnitOfWork>());
            //ObjectFactory.Configure(c =>c.For<IEntityBuilder>().Use<RavenEntityBuilder>());
            //ObjectFactory.Configure(c =>c.For<IFileStorageService>().Use<RavenFileStorageService>());
            //ObjectFactory.Configure(c =>c.For<ILookupService>().Use<RavenLookupService>());
            //ObjectFactory.Configure(c =>c.For<IIdentityProvider>().Use<IdentityProviderService>());
            //ObjectFactory.Configure ( c => c.For<ISessionProvider> ( ).Use<RavenUnitOfWorkSessionProvider> ( ) );

            // Cache
           //ObjectFactory.Configure( c=>c.For<ICachedLookupService>().Use(
           //     context => new CachedLookupService(
           //                    context.GetInstance<ILookupService>(), new MemoryCache("LookupCache"))));

            // Domain Event Service - per transaction
            RegisterDomainEventService(ObjectFactory.Container);

            ObjectFactory.Configure(x =>
                x.Scan(scanner =>
            {
                // In the scan operation, include all needed dlls as defined in the helper class.
                // be cautious in the future - this could still pick up unwanted assemblies,
                // such as the stray test project that mistakenly ends up in the bin folder.
                // so consider those possibilities if errors pop up, and you're led here.
                // scanner.AssembliesFromApplicationBaseDirectory(AutoRegistrationAssemblyHelper.ShouldStructureMapIncludeAssembly);
                scanner.AssembliesFromApplicationBaseDirectory( AutoRegistrationAssemblyHelper.ShouldStructureMapIncludeAssembly );

                scanner.LookForRegistries();

                // Register all boostrapper tasks
                scanner.AddAllTypesOf<IBootstrapperTask>();

                //Register all ObjectMappers
                scanner.AddAllTypesOf<IObjectMapper>();

                scanner.WithDefaultConventions();
            }));

            return ObjectFactory.Container;
        }

        /// <summary>
        /// Registers the domain event service.
        /// </summary>
        /// <param name="container">The container.</param>
        protected virtual void RegisterDomainEventService ( IContainer container )
        {
             //Domain Event Service - per request scope
             container.Configure(c => c.For<IDomainEventService>().HttpContextScoped().Use<DomainEventService>());
        }

        /// <summary>
        /// Configures the pillar IoC.
        /// </summary>
        /// <param name="container">The container.</param>
        protected virtual void ConfigurePillarIoC(IContainer container)
        {
            PillarIoC.SetContainerProvider(() => new Pillar.IoC.StructureMap.Container(container));
            PillarIoC.Bootstrap();
        }

        /// <summary>
        /// Configures the agatha.
        /// </summary>
        /// <param name="appContainer">The app container.</param>
        protected virtual void ConfigureAgatha(IContainer appContainer)
        {
            var structureMapContainer = new Agatha.StructureMap.Container ( appContainer );
            IoC.Container = structureMapContainer;

            var serviceLayerConfiguration = new ServiceLayerConfiguration(structureMapContainer);

            // register request and response assemblies
            var messageRegex = new Regex("^Asam.Ppc.Service.Messages$");
            List<Assembly> messageAssebllies = AppDomain.CurrentDomain.GetAssembliesFromApplicationBaseDirectory()
                .Where(x => messageRegex.IsMatch(x.GetName().Name))
                .ToList();
            messageAssebllies.ForEach(
                x =>
                {
                    List<Type> types =
                        x.GetTypes(). //Where(
                        //type => !type.IsSubclassOf(typeof (Request)) && !type.IsSubclassOf(typeof (Response))).
                            ToList();
                    //types.ForEach(KnownTypeProvider.Register);

                    serviceLayerConfiguration.AddRequestAndResponseAssembly(x);
                });

            // register request handler assemblies
            var serviceRegex = new Regex("^Asam.Ppc.Service.Handlers$");
            List<Assembly> serviceAssemblies = AppDomain.CurrentDomain.GetAssembliesFromApplicationBaseDirectory()
                .Where(x => serviceRegex.IsMatch(x.GetName().Name))
                .ToList();
            serviceAssemblies.ForEach(
                x => serviceLayerConfiguration.AddRequestHandlerAssembly(x) );

            // register agatha conventions
            serviceLayerConfiguration.Use<RequestHandlerBasedConventions>();

            serviceLayerConfiguration.RequestProcessorImplementation = typeof(NHibernateTransactionRequestProcessor);

            // register business exception type
            //serviceLayerConfiguration.BusinessExceptionType = typeof(BusinessRuleException);

            serviceLayerConfiguration.Initialize();
        }


        /// <summary>
        /// Registers the document session provider.
        /// </summary>
        /// <param name="container">The container.</param>
        protected virtual void RegisterDocumentSessionProvider ( IContainer container )
        {
        }

        /// <summary>
        /// Runs the bootstrapper tasks.
        /// </summary>
        /// <param name="container">The container.</param>
        protected virtual void RunBootstrapperTasks(IContainer container)
        {
            var tasks = container.GetAllInstances<IBootstrapperTask> ();
            foreach ( var bootstrapperTask in tasks )
            {
                bootstrapperTask.Execute ();
            }
        }
    }
}
