using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ffa_tool.Commands;
using ffa_tool.DomainModels;

namespace ffa_tool.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public AirportDataViewModel AirportDataViewModel { get; init; }

    public MainWindowViewModel(AirportManagerModel airportManager, AirportModel airportModel)
    {
        AirportDataViewModel = new(airportManager, airportModel);
    }
}
