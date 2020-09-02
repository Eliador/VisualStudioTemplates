using ProjectName.App.Windows;
using ProjectName.App.Windows.ViewModels;

namespace ProjectName.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase<MainWindowViewModel>
    {
        public MainWindow() : base()
        {
            InitializeComponent();
        }
    }
}
