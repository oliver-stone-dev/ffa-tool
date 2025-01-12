
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.Commands;
using ffa_tool.Models;
using ffa_tool.ViewModels;

namespace ffa_tool.Commands;

public class AirportSearchCommand : CommandBase
{
    private readonly Airport _airport;
    private readonly AirportSearchViewModel _airportSearchViewModel;

    public AirportSearchCommand(AirportSearchViewModel airportSearchViewModel, Airport airport)
    {
        _airport = airport;
        _airportSearchViewModel = airportSearchViewModel;
    }

    public override bool CanExecute(object? parameter)
    {
        return base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        Trace.WriteLine("Searching!");
    }
}
