// unset

using Coherent.Project.Wpf.Template.Base.Redux.Reducers;
using Coherent.Project.Wpf.Template.Base.Redux.Reducers.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Coherent.Project.Wpf.Template.Base.Services;
using Coherent.Project.Wpf.Template.Gui.ViewModels;
using Coherent.Project.Wpf.Template.Gui.Views;
using MediatR;
using MediatR.Pipeline;
using ReactiveUI;
using Redux;
using SimpleInjector;
using Splat;
using Splat.SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Gui
{
    public static class Bootstrapper
    {
        public static Container CreateContainer()
        {
            var container = new Container();

            #region Redux

            container.Register<IDeviceStateReducer, DeviceStateReducer>();
            container.Register<IApplicationReducer, ApplicationReducer>();

            container.Register<IStore<ApplicationState>>(
                () => new Store<ApplicationState>(container.GetInstance<IApplicationReducer>().Reduce,
                    ApplicationState.CreateInitialState()), Lifestyle.Singleton);

            #endregion


            #region Services

            container.Register<IDeviceService, DeviceService>(Lifestyle.Singleton);

            #endregion


            #region Mediator

            container.RegisterSingleton<IMediator, Mediator>();

            Assembly assembly = GetAssembly();
            container.Register(typeof(IRequestHandler<,>), assembly);
            container.Register(typeof(INotificationHandler<>), assembly);

            RegisterHandlers(container, typeof(INotificationHandler<>), new[] {assembly});
            RegisterHandlers(container, typeof(IRequestExceptionAction<,>), new[] {assembly});
            RegisterHandlers(container, typeof(IRequestExceptionHandler<,,>), new[] {assembly});

            //Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>),
                new[] {
                    typeof(RequestExceptionProcessorBehavior<,>), typeof(RequestExceptionActionProcessorBehavior<,>),
                    typeof(RequestPreProcessorBehavior<,>), typeof(RequestPostProcessorBehavior<,>),
                    typeof(EmptyPipelineBehavior<,>)
                });

            container.Collection.Register(typeof(IRequestPreProcessor<>), new[] {typeof(EmptyRequestPreProcessor<>)});
            container.Collection.Register(typeof(IRequestPostProcessor<,>),
                new[] {typeof(EmptyRequestPostProcessor<,>)});

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);

            #endregion


            #region GUI

            container.Register<MainViewModel>();
            container.Register<MainWindow>();

            // container.Register<IViewFor<MainViewModel>, MainWindow>();
            container.Register<IViewFor<DeviceAViewModel>, DeviceAView>();
            container.Register<IViewFor<DeviceBViewModel>, DeviceBView>();

            var initializer = new SimpleInjectorInitializer();

            Locator.SetLocator(initializer);

            // Register ReactiveUI dependencies
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();


            // Actual SimpleInjector registration
            container.UseSimpleInjectorDependencyResolver(initializer);
            container.Options.AllowOverridingRegistrations = true;

            #endregion


#if DEBUG
            container.Verify(VerificationOption.VerifyAndDiagnose);
#endif
            return container;
        }


        private static Assembly GetAssembly()
        {
            // TODO: replace this
            var assemblyNamespace = "Coherent.Project.Wpf.Template.Base";
            if (assemblyNamespace == "Coherent.Project.Wpf.Template.Base")
            {
#warning Template namespace, if your use this template consider renaming
            }

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .Single(x => !string.IsNullOrWhiteSpace(x.FullName) && x.FullName.Contains(assemblyNamespace));
        }


        private static void RegisterHandlers(Container container, Type collectionType, Assembly[] assemblies)
        {
            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            IEnumerable<Type> handlerTypes = container.GetTypesToRegister(collectionType, assemblies,
                new TypesToRegisterOptions {IncludeGenericTypeDefinitions = true, IncludeComposites = false});

            container.Collection.Register(collectionType, handlerTypes);
        }
    }


    public class EmptyPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            return next();
        }
    }

    public class EmptyRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public class EmptyRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}