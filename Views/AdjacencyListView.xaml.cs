using ACSVisualization.ViewModels;
using System.Windows.Controls;

namespace ACSVisualization.Views
{
    public partial class AdjacencyListView : UserControl
    {
        public AdjacencyListView()
        {
            DataContext = new AdjacencyListViewModel();
            InitializeComponent();
        }
    }
}
