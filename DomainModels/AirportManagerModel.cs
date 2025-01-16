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
    private readonly AirportModel _airportModel;

    public AirportManagerModel(AirportModel airportModel, IAirportService airportService)
    {
        _airportModel = airportModel;
        _airportService = airportService;
    }

    public IEnumerable<(int,string)> SearchAirports(string text)
    {
        var airports = new List<(int, string)>();

        var airport = _airportService.GetAirportById(Convert.ToInt32(text));

        airports.Add(new(airport.AirportId, airport.Name!));

        return airports;
    }
    
    public void LoadModelFromAirportId(int id)
    {
        _airportModel.ResetAirport();
        _airportModel.ClearTerminals();

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

    public bool LoadModelFromAirportCode(string code)
    {
        if (string.IsNullOrEmpty(code)) return false;

        var airport = _airportService.GetAirportByCode(code);
        if (airport == null) return false;

        _airportModel.ResetAirport();
        _airportModel.ClearTerminals();

        _airportModel.AirportId = airport.AirportId;
        _airportModel.Name = airport.Name;
        _airportModel.Code = airport.Code;
        _airportModel.Website = airport.Website;
        _airportModel.Country = airport.Country;

        var terminals = _airportService.GetTerminalsByAirportId(airport.AirportId);
        if (terminals == null || terminals.Count() == 0) return false;

        foreach (var terminal in terminals)
        {
            _airportModel.AddTerminal(new TerminalModel
            {
                TerminalId = terminal.TerminalId,
                Name = terminal.Name
            });
        }

        return true;
    }

    public void SaveCurrentModel()
    {
        _airportService.UpdateAirport(_airportModel);
        //_airportService.UpdateTerminals(_airportModel.Terminals);
    }

    public void ClearCurrentModel()
    {
        _airportModel.ResetAirport();
        _airportModel.ClearTerminals();
    }

    public int GetCurrentAirportId()
    {
        return _airportModel.AirportId;
    }
}
