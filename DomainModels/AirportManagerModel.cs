using ffa_tool.DatabaseModels;
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
    
    public bool LoadModelFromAirportId(int id)
    {
        if (id == 0) return false;

        var airport = _airportService.GetAirportById(id);
        if (airport == null) return false;
        UpdateAirportModelData(airport);

        var terminals = _airportService.GetTerminalsByAirportId(airport.AirportId);
        if (terminals == null || terminals.Count() == 0) return false;
        UpdateAirportModelTerminalData(terminals);

        return true;
    }

    public bool LoadModelFromAirportCode(string code)
    {
        if (string.IsNullOrEmpty(code)) return false;

        var airport = _airportService.GetAirportByCode(code);
        if (airport == null) return false;
        UpdateAirportModelData(airport);

        var terminals = _airportService.GetTerminalsByAirportId(airport.AirportId);
        if (terminals == null || terminals.Count() == 0) return false;
        UpdateAirportModelTerminalData(terminals);

        return true;
    }

    public void SaveCurrentModel()
    {
        _airportService.UpdateAirport(_airportModel);
        //_airportService.UpdateTerminals(_airportModel.Terminals);
    }

    public void DeleteCurrentModel()
    {
        _airportService.DeleteAirport(_airportModel.AirportId);
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

    public string GetLastTerminalName()
    {
        var terminal = _airportModel.Terminals.Last();

        if (terminal == null) return string.Empty;

        return terminal.Name!;
    }

    public int GetTerminalIdFromName(string name)
    {
        var terminal = _airportModel.Terminals.Where(t => t.Name == name).FirstOrDefault();

        if (terminal == null) return 0;

        return terminal.TerminalId;
    }

    public void AddTerminalToModel()
    {
        var len = _airportModel.Terminals.Count();
        var name = $"Terminal {len + 1}";
        _airportModel.AddTerminal(new TerminalModel { TerminalId = 0, Name = name });
    }

    public void DeleteTerminalFromModel(int id)
    {
        _airportModel.RemoveTerminal(id);
    }

    private void UpdateAirportModelData(AirportModel airportModel)
    {
        _airportModel.ResetAirport();

        _airportModel.AirportId = airportModel.AirportId;
        _airportModel.Name = airportModel.Name;
        _airportModel.Code = airportModel.Code;
        _airportModel.Website = airportModel.Website;
        _airportModel.Country = airportModel.Country;
    }

    private void UpdateAirportModelTerminalData(IEnumerable<TerminalModel> terminals)
    {
        _airportModel.ClearTerminals();

        foreach (var terminal in terminals)
        {
            _airportModel.AddTerminal(new TerminalModel
            {
                TerminalId = terminal.TerminalId,
                Name = terminal.Name
            });
        }
    }
}
