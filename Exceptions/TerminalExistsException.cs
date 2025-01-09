using ffa_tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Exceptions;

public class TerminalExistsException : Exception
{
    public Terminal ExistingTerminal { get; }
    public Terminal IncomingTerminal { get; }

    public TerminalExistsException(Terminal existingTerminal, Terminal incomingTerminal)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    public TerminalExistsException(string? message, Terminal existingTerminal, Terminal incomingTerminal) : base(message)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    public TerminalExistsException(string? message, Exception? innerException, Terminal existingTerminal, Terminal incomingTerminal) : base(message, innerException)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    protected TerminalExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
