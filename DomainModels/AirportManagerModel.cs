using ffa_tool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.DomainModels;

public class AirportManagerModel
{
    private readonly IAirportService _airportService;
    private readonly ITerminalService _terminalService;
    private readonly AirportModel _airportModel;

    public AirportManagerModel(AirportModel airportModel, IAirportService airportService, ITerminalService terminalService)
    {
        _airportModel = airportModel;
        _airportService = airportService;
        _terminalService = terminalService;
    }

    public IEnumerable<(int,string)> SearchAirports(string text)
    {
        var airports = new List<(int, string)>();

        airports.Add(new(1, "london"));

        return airports;
    }
    
    public void LoadModelFromAirportId(int id)
    {
        _airportModel.Clear();

        _airportModel.AirportId = 1;
        _airportModel.Name = "London Heathrow";
        _airportModel.Code = "LHR";
        
        var terminal2 = new TerminalModel() { TerminalId = 1, Name = "Terminal 2" };
        var terminal3 = new TerminalModel() { TerminalId = 2, Name = "Terminal 3" };
        var terminal4 = new TerminalModel() { TerminalId = 3, Name = "Terminal 4" };
        var terminal5 = new TerminalModel() { TerminalId = 4, Name = "Terminal 5" };

        _airportModel.AddTerminal(terminal2);
        _airportModel.AddTerminal(terminal3);
        _airportModel.AddTerminal(terminal4);
        _airportModel.AddTerminal(terminal5);


        //Load data from database to current model

    }

    public void SaveCurrentModel()
    {
        //Save current airportmodeld to database
    }

    public void ClearCurrentModel()
    {
        _airportModel.Clear();
    }

    public int GetCurrentAirportId()
    {
        return _airportModel.AirportId;
    }
}
