using System.Collections.Generic;
using System.Collections.ObjectModel;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class ToDoListViewModel : ViewModelBase
{
    public ToDoListViewModel()
    {
        ISuichukoService service = new SuichukoService();
        ListItems = new ObservableCollection<ToDoItem>(items);
    }

    public ObservableCollection<ToDoItem> ListItems { get; }
}