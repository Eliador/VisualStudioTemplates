using GalaSoft.MvvmLight;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfNetCoreProjectName.Windows
{
    public abstract class WindowBase<TViewModel> : Window
        where TViewModel: ViewModelBase
    {
        public TViewModel ViewModel { get; internal set; }

        public WindowBase()
        {
            var serviceProvider = (ServiceProvider)Application.Current.FindResource(typeof(ServiceProvider));

            ViewModel = (TViewModel)serviceProvider.GetService(typeof(TViewModel));
            DataContext = ViewModel;

            DataContextChanged += OnDataContextChanged;
        }

        protected virtual void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = (TViewModel)e.NewValue;
        }
    }
}
