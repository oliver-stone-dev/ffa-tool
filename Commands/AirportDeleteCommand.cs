using ffa_tool.DomainModels;
using ffa_tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.Commands;

public class AirportDeleteCommand : CommandBase
{
    private readonly AirportManagerModel _airportManager;

    public AirportDeleteCommand(AirportManagerModel airportManager)
    {
        _airportManager = airportManager;
    }

    public override bool CanExecute(object? parameter)
    {
        return (base.CanExecute(parameter));
    }

    public override void Execute(object? parameter)
    {
        Trace.WriteLine("Airport deleted!");
    }
}
