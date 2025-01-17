using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.Exceptions;

namespace ffa_tool.DomainModels;

public class AirportModel
{
    public int AirportId { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Website { get; set; }
    public string? Country { get; set; }

    private readonly List<TerminalModel> _terminals;

    public IEnumerable<TerminalModel> Terminals => _terminals;

    public AirportModel()
    {
        _terminals = new();
    }

    public void AddTerminal(TerminalModel terminal)
    {
        if (terminal == null)
        {
            return;
        }


        if (terminal.TerminalId != 0)
        {
            foreach (var t in Terminals)
            {
                if (terminal.TerminalId == t.TerminalId)
                {
                    throw new TerminalExistsException(t, terminal);
                }
            }
        }

        _terminals.Add(terminal);
    }

    public void RemoveTerminal(int terminalId)
    {
        var terminal = Terminals.FirstOrDefault(t => t.TerminalId == terminalId);

        if (terminal != null)
        {
            _terminals.Remove(terminal);
        }
    }

    public TerminalModel GetTerminalByName(string name)
    {
        var terminals = _terminals.Where(t => t.Name == name).FirstOrDefault();
        if (terminals != null)
        {
            return terminals;
        }

        return null!;
    }

    public TerminalModel GetTerminalById(int id)
    {
        var terminals = _terminals.Where(t => t.TerminalId == id).FirstOrDefault();
        if (terminals != null)
        {
            return terminals;
        }

        return null!;
    }

    public void ResetAirport()
    {
        AirportId = 0;
        Name = string.Empty;
        Code = string.Empty;
        Website = string.Empty;
        Country = string.Empty;
    }

    public void ClearTerminals()
    {
        _terminals.Clear();
    }
}

