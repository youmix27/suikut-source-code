using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class ToDoListViewModel : ViewModelBase
{
    private ISuichukoService service;
    
    public ToDoListViewModel(SuichukoContext context)
    {
        service =  new SuichukoService(context);
        musiques = new ObservableCollection<Musique>(service.FindAllMusiques().Cast<Musique>());
        foreach (var musique in musiques)
        {
            Console.WriteLine(musique.Libelle);
        }
    }

    public ObservableCollection<Musique> musiques { get; set; }
}