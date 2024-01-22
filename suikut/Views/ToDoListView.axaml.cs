using Avalonia.Controls;
using suikut.ViewModels;

namespace suikut.Views
{
    public partial class ToDoListView : UserControl
    {
        private ToDoListViewModel _viewModel;
        
        public ToDoListView()
        {
            InitializeComponent();
            _viewModel = (ToDoListViewModel)this.DataContext;
        }
    }
}