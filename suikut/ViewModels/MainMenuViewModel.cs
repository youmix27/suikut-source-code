using System;
using System.Collections.Generic;

namespace suikut.ViewModels;

public class MainMenuViewModel : ViewModelBase
{
    public bool isAdmin { get; set; }

    public MainMenuViewModel()
    {
        if (Environment.GetEnvironmentVariable("USER_ROLE") == "Administrator")
        {
            isAdmin = true;
        }
        else
        {
            isAdmin = false;
        }
    }
    
}