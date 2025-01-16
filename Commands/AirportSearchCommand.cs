
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.Commands;
using ffa_tool.DomainModels;
using ffa_tool.ViewModels;

namespace ffa_tool.Commands;

public class AirportSearchCommand : CommandBase
{
    private readonly AirportManagerModel _airportManager;
    private readonly AirportDataViewModel _airportDataViewModel;

    public AirportSearchCommand(AirportDataViewModel airportDataViewModel, 
                                AirportManagerModel airportManager)
    {
        _airportDataViewModel = airportDataViewModel;
        _airportManager = airportManager;
    }

    public override void Execute(object? parameter)
    {
        //var airports = _airportManager.SearchAirports(_airportDataViewModel.SearchText!);
        //var airport = _airportManager.GetAirportById(Convert.ToInt32(_airportDataViewModel.SearchText));
        //_airportDataViewModel.SetAirportInfo(airport);

        //var id = _airportManager.GetCurrentAirportId();
        //_airportManager.SearchAirports(_airportDataViewModel.SearchText!);
        //_airportManager.LoadModelFromAirportId(id);
        //_airportDataViewModel.RefreshAirportData();
        _airportManager.LoadModelFromAirportCode(_airportDataViewModel.SearchText!);
        _airportDataViewModel.RefreshAirportData();
    }
}
