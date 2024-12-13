using ACSVisualization.ViewModels;
using System.Windows;

namespace ACSVisualization.Views
{
    public partial class ShellView : Window
    {
        public ShellView()
        {
            DataContext = new ShellViewModel();
            InitializeComponent();
        }
    }
}