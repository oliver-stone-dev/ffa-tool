using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Commands;

public class SaveChangesCommand : CommandBase
{
    private readonly AirportManagerModel _airportManager;

    public SaveChangesCommand(AirportManagerModel airportManager)
    {
        _airportManager = airportManager;
    }

    public override bool CanExecute(object? parameter)
    {
        return (base.CanExecute(parameter));
    }

    public override void Execute(object? parameter)
    {
        Trace.WriteLine("Upload Data!");
    }
}
