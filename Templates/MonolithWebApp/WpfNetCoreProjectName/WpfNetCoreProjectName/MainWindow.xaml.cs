using WpfNetCoreProjectName.Windows;
using WpfNetCoreProjectName.Windows.ViewModels;

namespace WpfNetCoreProjectName
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
