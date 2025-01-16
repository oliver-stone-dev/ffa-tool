using ffa_tool.DatabaseModels;
using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Services;

public interface IAirportService
{
    AirportModel GetAirportById(int id);
    AirportModel GetAirportByCode(string code);
    void UpdateAirport(AirportModel airportModel);

    IEnumerable<TerminalModel> GetTerminalsByAirportId(int id);

}
