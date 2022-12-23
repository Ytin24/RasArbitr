using CefSharp.DevTools.CSS;
using Newtonsoft.Json;
using RasArbitrCore;
using RasArbitrCore.API;
using RasArbitrCore.Model;
using RasArbitrWPF.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using WPFCustomMessageBox;

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

    public TextInserter Sides { get; set; }
    public TextInserter Cases { get; set; }
    // ТЕСТ //
    private bool enabled = true;
    public bool Enabled
    {
        get=> enabled;
        set
        {
            enabled = value;
            OnPropertyChanged("Enabled");
        }
    }

    private string btnStatus = "Запросить";
    public string BtnStatus
    {
        get => btnStatus;
        set
        {
            btnStatus = value;
            OnPropertyChanged("BtnStatus");
        }
    }

    private ExecCommand searchCommand;
    public ExecCommand SearchCommand
    {
        get
        {
            return searchCommand ??
                (searchCommand = new ExecCommand(async o =>
                {
                    Enabled = false;
                    BtnStatus = "Ожидайте";
                    await Task.Delay(1);

                    List<PostRequest.Side> sides = new();
                    foreach(var side in Sides.ItemText) {
                        if (side != "") {
                            sides.Add(new() {
                                Name = side,
                                Type = -1,
                                ExactMatch = false,
                            });
                        } 
                    }
                    List<string> cases = new();
                    foreach (var @case in Cases.ItemText) {
                        if (@case != "") {
                            cases.Add(@case);
                        }
                    }
                    PostRequest PostRequestbody = new() {
                        Text = request.Text,

                        Cases = cases,
                        Sides = sides,
                        
                        DateFrom = request.DateFrom,
                        DateTo = request.DateTo,

                        IsFinished = IsFinished
                    };

                    if (selectedType != "") PostRequestbody.DisputeTypes = new() { selectedType };
                    if (selectedCategory != "") PostRequestbody.StatDisputeCategory = selectedCategory;
                    if (selectedCourt != "") PostRequestbody.Courts = new() { selectedCourt };
                    if (selectedYear != "") PostRequestbody.DocYears = new() { selectedYear };
                    if (selectedInstType != "") PostRequestbody.InstanceType = new() { selectedInstType };

                    await GetData(PostRequestbody);
                    BtnStatus = "Успешно!";
                    await Task.Delay(1000);

                    BtnStatus = "Запросить";
                    Enabled = true;
                }, o => enabled));
        }
    }
    private async Task GetData(PostRequest Body) {
        TestSource.Clear();
        var cookies = await RasWeb.GetCookies();
        var json = JsonConvert.SerializeObject(Body, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        PostResult RawData = await RasApi.Post(json, cookies);
        if (RawData.Success == false) return;
        foreach(var data in RawData.Result.Items) {
            var d = new ItemAnswerView(data);
            TestSource.Add(d);
            //TestSource.Add(data.Type);
        }
    }
    private ItemAnswerView _itemAnswerViewSelected;
    public ItemAnswerView itemAnswerViewSelected{
        get => _itemAnswerViewSelected;
        set => Set(ref _itemAnswerViewSelected, value);
}
private ObservableCollection<ItemAnswerView> _TestSource = new();
    public ObservableCollection<ItemAnswerView> TestSource {
        get => _TestSource;
        set => Set(ref _TestSource, value);
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

    // Категории споров //
    private StatDisputeCategoryCodes categories = new();
    public StatDisputeCategoryCodes Categories
    {
        get => categories;
    }

    private string selectedCategory = string.Empty;
    public string SelectedCategory
    {
        get => selectedCategory;
        set => selectedCategory = categories.GetCode(value);
    }

    // Номер дела //
    private List<string> cases = new() { string.Empty };
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

    private string selectedInstType = string.Empty;
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

    private string isFinished = string.Empty;
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

    private string selectedYear = string.Empty;
    public string? SelectedYear
    {
        get => selectedYear;
        set => selectedYear = value;
    }
    #endregion

    private ExecCommand itemSelectCommand;
    public ExecCommand ItemSelectCommand
    {
        get
        {
            return itemSelectCommand ??
                (itemSelectCommand = new ExecCommand(o =>
                {
                    if (itemAnswerViewSelected != null)
                        ShowTest();
                }));
        }
    }

    private async void ShowTest()
    {
        MessageBoxResult result = CustomMessageBox.ShowOKCancel(
            "Вы хотите открыть документ или перейти на сайт для подробной информации?",
            "Выберите действие",
            "Открыть документ",
            "Перейти на сайт");
        if(result == MessageBoxResult.OK) {
            //Process.Start("explorer.exe", await RasApi.DowloadFile(itemAnswerViewSelected));
            Process.Start("explorer.exe", itemAnswerViewSelected.FileName.ToString());
        }
        else if (result == MessageBoxResult.Cancel) {
            Process.Start("explorer.exe",itemAnswerViewSelected.CaseId.ToString());
        }
    }
}