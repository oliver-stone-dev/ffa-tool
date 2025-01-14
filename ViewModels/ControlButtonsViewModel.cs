using ffa_tool.Commands;
using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.ViewModels;

public class ControlButtonsViewModel : ViewModelBase
{
    private readonly AirportManagerModel _airportManager;

    public ControlButtonsViewModel(AirportManagerModel airportManager)
    {
        _airportManager = airportManager;
        DeleteAirportCommand = new AirportDeleteCommand(_airportManager);
        SaveChangesCommand = new SaveChangesCommand(_airportManager);
        NewAirportCommand = new AirportAddCommand(_airportManager);
    }


    public ICommand DeleteAirportCommand { get; }
    public ICommand SaveChangesCommand { get; }
    public ICommand NewAirportCommand { get; }
}
