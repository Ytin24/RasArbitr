using System;
using System.Collections.Generic;
using System.Reactive.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace YLauncherAvalonia.ViewModel;

public class MainWindowVM : ViewModel
{

    
    public delegate void CloseWindow();

    public event CloseWindow Close;
   
    
    private WindowState _windowState = WindowState.Normal;
    
    public WindowState WindowState
    {
        get => _windowState;
        set => Set(ref _windowState, value);
    }
    public void TitleBarButtons_Click(string Name)
    {
        switch (Name)
        {
            case "Exit":
                Close.Invoke();
                break;
            case "Unwrap":
                if(WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
                else WindowState = WindowState.Maximized;
                break;
            case "Minimize":
                WindowState = WindowState.Minimized;
                break;
            
        }
    }

}