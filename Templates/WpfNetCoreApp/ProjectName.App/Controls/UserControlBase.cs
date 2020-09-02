using GalaSoft.MvvmLight;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace ProjectName.App.Controls
{
    public abstract class UserControlBase<TViewModel> : UserControl
        where TViewModel : ViewModelBase
    {
        public TViewModel ViewModel { get; private set; }

        protected UserControlBase()
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
