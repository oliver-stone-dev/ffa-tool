using ffa_tool.Commands;
using ffa_tool.DatabaseModels;
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

    private readonly ObservableCollection<DataGridViewModelItem<TerminalModel>> _selectedTerminalInfo;
    public IEnumerable<DataGridViewModelItem<TerminalModel>> SelectedTerminalInfo => _selectedTerminalInfo;

    private readonly ObservableCollection<DataGridViewModelItem<TerminalModel>> _terminalNames;
    public IEnumerable<DataGridViewModelItem<TerminalModel>> TerminalNames => _terminalNames;

    private DataGridViewModelItem<TerminalModel> _selectedTerminalName;

    public DataGridViewModelItem<TerminalModel> SelectedTerminalName
    {
        get =>_selectedTerminalName!;

        set 
        {
            _selectedTerminalName = value;
            OnPropertyChanged(nameof(SelectedTerminalName));

            if (_selectedTerminalName == null) return;

            var terminal = _airportModel.GetTerminalByName(_selectedTerminalName.Value);
            if (terminal == null) return;

            _selectedTerminalInfo.Clear();

            _selectedTerminalInfo.Add(new DataGridViewModelItem<TerminalModel>(terminal, "TerminalId", true));
            _selectedTerminalInfo.Add(_selectedTerminalName);
        }
    }

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

    public AirportDataViewModel(AirportManagerModel airportManager, AirportModel airportModel)
    {
        _airportManager = airportManager;
        _airportModel = airportModel;

        _airportInfo = new ObservableCollection<DataGridViewModelItem<AirportModel>>();
        _selectedTerminalInfo = new ObservableCollection<DataGridViewModelItem<TerminalModel>>();
        _terminalNames = new ObservableCollection<DataGridViewModelItem<TerminalModel>>();

        SearchCommand = new AirportSearchCommand(this, airportManager);
        AddTerminalCommand = new TerminalAddCommand(this);
        DeleteTerminalCommand = new TerminalDeleteCommand(airportManager);
        DeleteAirportCommand = new AirportDeleteCommand(airportManager);
        SaveChangesCommand = new SaveChangesCommand(this, airportManager);
        NewAirportCommand = new AirportAddCommand(airportManager);
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
            _terminalNames.Add(new DataGridViewModelItem<TerminalModel>(terminal, "Name", false));
        }

        _selectedTerminalName = _terminalNames.FirstOrDefault()!;
    }

    public ICommand AddTerminalCommand { get; }
    public ICommand DeleteTerminalCommand { get; }
    public ICommand SearchCommand { get; }
    public ICommand DeleteAirportCommand { get; }
    public ICommand SaveChangesCommand { get; }
    public ICommand NewAirportCommand { get; }
}
