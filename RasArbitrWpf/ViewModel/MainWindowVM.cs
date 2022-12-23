using Newtonsoft.Json;
using RasArbitrCore;
using RasArbitrCore.API;
using RasArbitrCore.Model;
using RasArbitrWPF.UC;
using System;
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

    public TextInserter Sides { get; set; }
    public TextInserter Cases { get; set; }
    // ТЕСТ //
    private ExecCommand searchCommand;
    public ExecCommand SearchCommand
    {
        get
        {
            return searchCommand ??
                (searchCommand = new ExecCommand(o =>
                {
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
                        
                        Judges = new() {},
                        Cases = cases,
                        Sides = sides,
                        
                        DateFrom = request.DateFrom,
                        DateTo = request.DateTo,

                    };
                    //DisputeTypes = new() { selectedType },
                    //StatDisputeCategory = selectedCategory,
                    // Courts = new() { SelectedCourt }
                    if (selectedType != null) PostRequestbody.DisputeTypes = new() { selectedType };
                    if (SelectedCategory != null) PostRequestbody.StatDisputeCategory = selectedCategory;
                    if (SelectedCourt != "") PostRequestbody.Courts = new() { SelectedCourt };
                    if (isFinished != null) PostRequestbody.IsFinished = isFinished;
                    if (SelectedYear != null && SelectedYear != "") PostRequestbody.DocYears = new() { SelectedYear };
                    if (SelectedInstType != null) PostRequestbody.InstanceType = new() { SelectedInstType };
                    GetData(PostRequestbody);
                }));
        }
    }
    private async void GetData(PostRequest Body) {

        var a = await RasWeb.GetCookies();
        var json = JsonConvert.SerializeObject(Body, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //var sitejson = "{\"GroupByCase\":false,\"Count\":25,\"Page\":1,\"DateFrom\":\"2000-01-01T00:00:00\",\"DateTo\":\"2030-01-01T23:59:59\",\"Sides\":[],\"Judges\":[],\"Cases\":[],\"Text\":\"\"}";
        //              {"GroupByCase":false,"Count":25,"Page":1,"DateFrom":"2000-01-01T00:00:00","DateTo":"2030-01-01T00:00:00","Sides":[],"Judges":[],"Cases":[],"Text":""}
        //              {"GroupByCase":false,"Count":25,"Page":1,"DateFrom":"2000-01-01T00:00:00","DateTo":"2030-01-01T00:00:00","Sides":[{"Name":"","Type":-1,"ExactMatch":true}],"Judges":[],"Cases":[""]}
        //var booleanjson = json == sitejson;
        PostResult d = await RasApi.Post(json, a);
        if (d.Result == null) return;
        var e = new ItemAnswerView(d.Result.Items[0]);
        TestSource.Add(e.FileName);
    }
    private List<Uri> _TestSource = new();
    public List<Uri> TestSource {
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