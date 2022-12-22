using RasArbitrCore.API;
using RasArbitrCore.Model;

using System.Collections.Generic;
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

    // ТЕСТ //
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
                        $"Категория спора: {selectedCategory}\n" +
                        $"Участник дела: {Side.Name}\n" +
                        $"Суд: {selectedCourt}\n" +
                        $"Дело: {Case}\n" +
                        $"Дата от: {request.DateFrom.ToString()}\n" +
                        $"Дата до: {request.DateTo.ToString()}\n" +

                        "\n" +

                        $"Тип Документа: {selectedInstType}\n" +
                        $"Завершён: {isFinished}\n" +
                        $"Год: {selectedYear}");
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

    private string? selectedCourt = null;
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

    private string? selectedType = null;
    public string SelectedType
    {
        get => selectedType;
        set => selectedType = types.GetCode(value);
    }

    // Категории споров //
    private StatDisputeCategoryCodes categories = new();
    public StatDisputeCategoryCodes Categories
    {
        get => categories;
    }

    private string? selectedCategory = null;
    public string SelectedCategory
    {
        get => selectedCategory;
        set => selectedCategory = categories.GetCode(value);
    }

    // Номер дела //
    private List<string?> cases = new() { null };
    public string Case
    {
        get => cases[0];
        set => cases.Insert(0, value);
    }

    //// ВЕРХНЯЯ ПАНЕЛЬ ////
    // Тип документа //
    private InstanceTypesCodes instTypes = new();
    public InstanceTypesCodes InstanceTypes
    {
        get => instTypes;
    }

    private string? selectedInstType = null;
    public string SelectedInstType
    {
        get => selectedInstType;
        set => selectedInstType = instTypes.GetCode(value);
    }

    // Статус //
    private StatusCodes statuses = new();
    public StatusCodes Statuses
    {
        get => statuses;
    }

    private string? isFinished = null;
    public string IsFinished
    {
        get => isFinished;
        set => isFinished = statuses.GetCode(value);
    }

    // Год //
    private Years years = new();
    public Years Years
    {
        get => years;
    }

    private string? selectedYear = null;
    public string? SelectedYear
    {
        get => selectedYear;
        set => selectedYear = value;
    }
    #endregion
}