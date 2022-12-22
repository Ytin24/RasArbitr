using RasArbitrCore.API;
using RasArbitrCore.Model;
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
    //TODO FixCommands for buttons
    //private void TitleBarButtons_Click(object Name)
    //{
    //    switch (Name.ToString())
    //    {
    //        case "Exit":
    //            Close.Invoke();
    //            break;
    //        case "Unwrap":
    //            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
    //            else WindowState = WindowState.Maximized;
    //            break;
    //        case "Minimize":
    //            WindowState = WindowState.Minimized;
    //            break;

    //    }
    //}

    ///////////////////////////////////////////////////////////////////

    private ExecCommand titleBtnCommand;
    public ExecCommand TitleBtnCommand
    {
        get
        {
            return titleBtnCommand ??
                (titleBtnCommand = new ExecCommand(o =>
                {
                    switch (o.ToString())
                    {
                        case "Exit":
                            Close.Invoke();
                            break;
                        case "Unwrap":
                            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
                            else WindowState = WindowState.Maximized;
                            break;
                        case "Minimize":
                            WindowState = WindowState.Minimized;
                            break;

                    }
                }));
        }
    }

    private ExecCommand searchCommand;
    public ExecCommand SearchCommand
    {
        get
        {
            return searchCommand ??
                (searchCommand = new ExecCommand(o =>
                {
                    MessageBox.Show($"Text: {request.Text}\n" +
                        $"Вид Спора: {selectedType}\n" +
                        $"Категория спора: {request.StatDisputeCategory}\n" +
                        $"Участник дела: {Side.Name}\n" +
                        $"Суд: {selectedCourt}\n" +
                        //$"Дело: {Case}\n" +
                        $"Дата от: {request.DateFrom.ToString()}\n" +
                        $"Дата до: {request.DateTo.ToString()}\n");
                }));
        }
    }

    #region RequestVM

    private PostRequest request = new();
    public PostRequest Request
    {
        get => request;
    }

    // Участник дела //
    private PostRequest.Side side = new();
    public PostRequest.Side Side
    {
        get => side;
    }

    // Суд //
    private CourtsCodes courts = new();
    public CourtsCodes Courts
    {
        get => courts;
    }

    private string selectedCourt = string.Empty;
    public string SelectedCourt
    {
        get => selectedCourt;
        set => selectedCourt = courts.GetCode(value);
    }

    // Виды споров //
    private DisputeTypesCodes types = new();
    public DisputeTypesCodes Types
    {
        get => types;
    }

    private string selectedType = string.Empty;
    public string SelectedType
    {
        get => selectedType;
        set => selectedType = types.GetCode(value);
    }

    #endregion
}