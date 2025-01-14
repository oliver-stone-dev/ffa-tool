using ffa_tool.DomainModels;
using ffa_tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Commands;

public class TerminalAddCommand : CommandBase
{
    private readonly AirportDataViewModel _airportDataViewModel;

    public TerminalAddCommand(AirportDataViewModel airportDataViewModel)
    {
        _airportDataViewModel = airportDataViewModel;
    }

    public override bool CanExecute(object? parameter)
    {
        return (base.CanExecute(parameter));
    }

    public override void Execute(object? parameter)
    {
        // Attempt to a add a new terminal
        //var airportId = _airportDataViewModel.GetCurrentAirportId();
        //if (airportId == 0) return;

        //_terminalManager.AddTerminal(new TerminalModel(), airportId);
        //_terminalDataViewModel.SetTerminalsForAirport(airportId);
    }
}
