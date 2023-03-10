using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using RasArbitrCore;
using YLauncherAvalonia.ViewModel;

namespace YLauncherAvalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = this.DataContext as MainWindowVM;
        vm.Close += () => { this.Close(0); };

        RasWeb.GetCookies();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        this.BeginMoveDrag(e);
    }
}