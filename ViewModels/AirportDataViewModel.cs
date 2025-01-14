using ffa_tool.Commands;
using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.ViewModels;

public class AirportDataViewModel : ViewModelBase
{
    private readonly AirportModel _airportModel;
    private readonly AirportManagerModel _airportManager;

    private readonly ObservableCollection<DataGridViewModelItem<AirportModel>> _airportInfo;
    public IEnumerable<DataGridViewModelItem<AirportModel>> AirportInfo => _airportInfo;

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;

        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    private readonly ObservableCollection<DataGridViewModelItem<TerminalModel>> _selectedTerminalInfo;
    public IEnumerable<DataGridViewModelItem<TerminalModel>> SelectedTerminalInfo => _selectedTerminalInfo;

    private readonly ObservableCollection<string> _terminalNames;
    public IEnumerable<string> TerminalNames => _terminalNames;

    private string? _selectedTerminalName;

    public string? SelectedTerminalName
    {
        get => _selectedTerminalName;

        set
        {
            _selectedTerminalName = value;
            OnPropertyChanged(nameof(SelectedTerminalName));
            SetTerminalDataByName(_selectedTerminalName!);
        }
    }

    public AirportDataViewModel(AirportManagerModel airportManager, AirportModel airportModel)
    {
        _airportManager = airportManager;
        _airportModel = airportModel;

        _airportInfo = new ObservableCollection<DataGridViewModelItem<AirportModel>>();
        _selectedTerminalInfo = new ObservableCollection<DataGridViewModelItem<TerminalModel>>();
        _terminalNames = new ObservableCollection<string>();

        SearchCommand = new AirportSearchCommand(this, airportManager);
        AddTerminalCommand = new TerminalAddCommand(this);
        DeleteTerminalCommand = new TerminalDeleteCommand(airportManager);
    }

    public void RefreshAirportData()
    {
        if (_airportInfo == null) return;
        if (_airportManager == null) return;

        _airportInfo.Clear();
        _airportInfo.Add(new DataGridViewModelItem<AirportModel>(_airportModel, "AirportId",true));
        _airportInfo.Add(new DataGridViewModelItem<AirportModel>(_airportModel, "Name", false));
        _airportInfo.Add(new DataGridViewModelItem<AirportModel>(_airportModel, "Code", false));
        _airportInfo.Add(new DataGridViewModelItem<AirportModel>(_airportModel, "Country", false));
        _airportInfo.Add(new DataGridViewModelItem<AirportModel>(_airportModel, "Website", false));

        _terminalNames.Clear();
        foreach (var terminal in _airportModel.Terminals)
        {
            if (string.IsNullOrEmpty(terminal.Name)) continue;
            _terminalNames.Add(terminal.Name);
        }
    }

    public void SetTerminalDataByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return;

        var terminal = _airportModel.GetTerminalByName(name);

        if (terminal == null) return;

        _selectedTerminalInfo.Clear();

        _selectedTerminalInfo.Add(new DataGridViewModelItem<TerminalModel>(terminal, "TerminalId", true));
        _selectedTerminalInfo.Add(new DataGridViewModelItem<TerminalModel>(terminal, "Name", false));
    }

    public ICommand AddTerminalCommand { get; }
    public ICommand DeleteTerminalCommand { get; }
    public ICommand SearchCommand { get; }
}
