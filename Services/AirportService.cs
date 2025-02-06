using ffa_tool.DatabaseModels;
using ffa_tool.Databases;
using ffa_tool.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Services;

public class AirportService : IAirportService
{
    public AirportModel GetAirportById(int id)
    {
        try
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
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }

        return null!;
    }

    public AirportModel GetAirportByCode(string code)
    {
        try
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
        }
        catch(Exception e)
        {
            Trace.WriteLine(e.Message);
        }

        return null!;
    }

    public void UpdateAirport(AirportModel airportModel)
    {
        try
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
                var terminals = terminalDatabase.Terminals.Where(t => t.AirportId == airportModel.AirportId);

                foreach (var terminal in terminals)
                {
                    var modelTerminal = airportModel.Terminals.Where(t => t.TerminalId == terminal.Id).FirstOrDefault();

                    if (modelTerminal != null)
                    {
                        terminal.Name = modelTerminal.Name;
                    }
                    else
                    {
                        terminalDatabase.Terminals.Remove(terminal);
                    }
                }

                terminalDatabase.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }
    }
    public void DeleteAirport(int id)
    {
        try
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
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }
    }

    public IEnumerable<TerminalModel> GetTerminalsByAirportId(int id)
    {
        try
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
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }

        return null!;
    }
}

