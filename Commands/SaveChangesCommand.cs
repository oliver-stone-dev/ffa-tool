using ffa_tool.DomainModels;
using ffa_tool.ViewModels;
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
    private readonly AirportDataViewModel _airportDataViewModel;

    public SaveChangesCommand(AirportDataViewModel airportDataViewModel,
                                AirportManagerModel airportManager)
    {
        _airportDataViewModel = airportDataViewModel;
        _airportManager = airportManager;
    }

    public override bool CanExecute(object? parameter)
    {
        return (base.CanExecute(parameter));
    }

    public override void Execute(object? parameter)
    {
        _airportManager.SaveCurrentModel();
        _airportManager.LoadModelFromAirportId(_airportManager.GetCurrentAirportId());
        _airportDataViewModel.RefreshAirportData();
    }
}
