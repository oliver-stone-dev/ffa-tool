using ffa_tool.DatabaseModels;
using ffa_tool.Databases;
using ffa_tool.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Services;

public class AirportService : IAirportService
{
    public AirportModel GetAirportById(int id)
    {
        using (var context = new AirportDatabaseContext())
        {
            var airport = context.Airports.Where(a => a.Id == id).FirstOrDefault();
            if (airport != null)
            {
                var airportModel = new AirportModel
                {
                    AirportId = airport.Id,
                    Name = airport.Name,
                    Code = airport.Code,
                    Country = airport.Country,
                    Website = airport.Website
                };

                return airportModel;
            }
        }

        return null!;
    }

    public AirportModel GetAirportByCode(string code)
    {
        using (var context = new AirportDatabaseContext())
        {
            var airport = context.Airports.Where(a => a.Code == code).FirstOrDefault();
            
            if (airport != null)
            {
                var airportModel = new AirportModel
                {
                    AirportId = airport.Id,
                    Name = airport.Name,
                    Code = airport.Code,
                    Country = airport.Country,
                    Website = airport.Website
                };

                return airportModel;
            }
        }

        return null!;
    }

    public void UpdateAirport(AirportModel airportModel)
    {
        using (var airportDatabase = new AirportDatabaseContext())
        {
            var airport = airportDatabase.Airports.Where(a => a.Id == airportModel.AirportId).FirstOrDefault();
            if (airport != null)
            {
                airport.Name = airportModel.Name;
                airport.Code = airportModel.Code;
                airport.Website = airportModel.Website;
                airport.Country = airportModel.Country;
                airportDatabase.SaveChanges();
            }
        }

        using (var terminalDatabase = new TerminalDatabaseContext())
        {
            foreach (var terminal in airportModel.Terminals)
            {
                var terminalData = terminalDatabase.Terminals.Where(t => t.Id == terminal.TerminalId).FirstOrDefault();

                if (terminalData == null)
                {
                    terminalDatabase.Terminals.Add(new Terminal { Name = terminal.Name, AirportId = airportModel.AirportId });
                }
                else
                {
                    terminalData.Name = terminal.Name;
                }

                terminalDatabase.SaveChanges();
            }
        }
    }
    public void DeleteAirport(int id)
    {
        using (var airportContext = new AirportDatabaseContext())
        {
            airportContext.Airports.Where(a => a.Id == id).ExecuteDelete();
        }

        using (var terminalContextx = new TerminalDatabaseContext())
        {
            terminalContextx.Terminals.Where(t => t.AirportId == id).ExecuteDelete();
        }
    }

    public IEnumerable<TerminalModel> GetTerminalsByAirportId(int id)
    {
        using (var context = new TerminalDatabaseContext())
        {
            var terminals = context.Terminals.Where(t => t.AirportId == id)
                                             .Select(t => new TerminalModel
                                             {
                                                 TerminalId = t.Id,
                                                 Name = t.Name
                                             })
                                             .ToList();

            if (terminals != null)
            {
                return terminals;
            }
        }

        return null!;
    }
}

