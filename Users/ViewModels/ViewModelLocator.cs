using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Autofac;
using Users.Services;
using Xamarin.Forms;

namespace Users.ViewModels
{
    public class ViewModelLocator
    {
        private static IContainer _container;

        #region Auto Wire ViewModels
        public static readonly BindableProperty AutoWireViewModelProperty =
          BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(
                CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
        #endregion

        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            RegisterViewModels(builder);

            _container = builder.Build();
        }
        public static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<UsersViewModel>();
            builder.RegisterType<UserDetailsViewModel>();
        }
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
