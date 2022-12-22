using System;
using System.Threading.Tasks;
using System.Windows;

namespace RasArbitrWPF.ViewModel;

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