using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.Exceptions;

namespace ffa_tool.Models;

public class Airport
{
    public int AirportId { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Website { get; set; }
    public string? Country { get; set; }

    private readonly List<Terminal> _terminals;

    public IEnumerable<Terminal> Terminals => _terminals;

    public Airport()
    {
        _terminals = new();
    }

    public void AddTerminal(Terminal terminal)
    {
        if (terminal == null)
        {
            return;
        }

        foreach (var t in Terminals)
        {
            if (terminal.TerminalId == t.TerminalId)
            {
                throw new TerminalExistsException(t,terminal);
            }
        }

        _terminals.Add(terminal);
    }

    public void RemoveTerminal(int terminalId)
    {
        var terminal = Terminals.First(t => t.TerminalId == terminalId);

        if (terminal != null)
        {
            _terminals.Remove(terminal);
        }
    }

    public Terminal GetTerminalByName(string name)
    {
        return _terminals.Where(t => t.Name == name).First();
    }

    public Terminal GetTerminalById(int id)
    {
        return _terminals.Where(t => t.TerminalId == id).FirstOrDefault()!;
    }
}

