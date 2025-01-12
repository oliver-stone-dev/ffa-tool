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
    private readonly ObservableCollection<DataGridViewModel> _airportInfo;
    public IEnumerable<DataGridViewModel> AirportInfo => _airportInfo;

    public AirportDataViewModel(Airport airport)
    {
        _airport = airport;
        _airportInfo = new ObservableCollection<DataGridViewModel>();

        SetAirportInfo();
    }

    private void SetAirportInfo()
    {
        if (_airport == null) return;
        if (_airportInfo == null) return;

        _airportInfo.Add(new DataGridViewModel("Id", _airport.AirportId.ToString(), true));
        _airportInfo.Add(new DataGridViewModel("Name", _airport.Name!, false));
        _airportInfo.Add(new DataGridViewModel("Code", _airport.Code!, false));
        _airportInfo.Add(new DataGridViewModel("Country", _airport.Country!, false));
        _airportInfo.Add(new DataGridViewModel("Website", _airport.Website!, false));
    }
}
