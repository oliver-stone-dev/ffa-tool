using ffa_tool.DomainModels;
using ffa_tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Commands;

public class TerminalDeleteCommand : CommandBase
{
    private readonly AirportDataViewModel _airportDataViewModel;
    private readonly AirportManagerModel _airportManagerModel;

    public TerminalDeleteCommand(AirportDataViewModel airportDataViewModel, AirportManagerModel airportManagerModel)
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
        var name = _airportDataViewModel.GetSelectedTerminalName();
        if (string.IsNullOrEmpty(name)) return;

        var id = _airportManagerModel.GetTerminalIdFromName(name);
        if (id != 0)
        {       
            _airportManagerModel.DeleteTerminalFromModel(id);
            _airportDataViewModel.RefreshAirportData();
        }
    }
}
