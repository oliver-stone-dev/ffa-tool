using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.Commands;

public class AirportAddCommand : CommandBase
{
    private readonly AirportManagerModel _airportManager;

    public AirportAddCommand(AirportManagerModel airportManager)
    {
        _airportManager = airportManager;
    }

    public override void Execute(object? parameter)
    {
        Trace.WriteLine("Add airport!");
    }
}
