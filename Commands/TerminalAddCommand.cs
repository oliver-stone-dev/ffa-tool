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
    private readonly AirportManagerModel _airportManagerModel;

    public TerminalAddCommand(AirportDataViewModel airportDataViewModel, AirportManagerModel airportManagerModel)
    {
        _airportDataViewModel = airportDataViewModel;
        _airportManagerModel = airportManagerModel;
    }

    public override bool CanExecute(object? parameter)
    {
        return (base.CanExecute(parameter));
    }

    public override void Execute(object? parameter)
    {
        _airportManagerModel.AddTerminalToModel();
        _airportDataViewModel.RefreshAirportData();

        var lastTerminalName = _airportManagerModel.GetLastTerminalName();
        if (string.IsNullOrEmpty(lastTerminalName)) return;
        _airportDataViewModel.SetSelectedTerminalName(lastTerminalName);

    }
}
