using ffa_tool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.ViewModels;

public class AirportDataViewModel : ViewModelBase
{
    private readonly Airport _airport;
    private readonly ObservableCollection<DataGridViewModelItem<Airport>> _airportInfo;
    public IEnumerable<DataGridViewModelItem<Airport>> AirportInfo => _airportInfo;

    public AirportDataViewModel(Airport airport)
    {
        _airport = airport;
        _airportInfo = new ObservableCollection<DataGridViewModelItem<Airport>>();

        SetAirportInfo();
    }

    private void SetAirportInfo()
    {
        if (_airport == null) return;
        if (_airportInfo == null) return;

        _airportInfo.Add(new DataGridViewModelItem<Airport>(_airport,"AirportId",true));
        _airportInfo.Add(new DataGridViewModelItem<Airport>(_airport, "Name", false));
        _airportInfo.Add(new DataGridViewModelItem<Airport>(_airport, "Code", false));
        _airportInfo.Add(new DataGridViewModelItem<Airport>(_airport, "Country", false));
        _airportInfo.Add(new DataGridViewModelItem<Airport>(_airport, "Website", false));
    }
}
