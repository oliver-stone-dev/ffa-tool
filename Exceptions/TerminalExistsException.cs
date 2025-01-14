using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Exceptions;

public class TerminalExistsException : Exception
{
    public TerminalModel ExistingTerminal { get; }
    public TerminalModel IncomingTerminal { get; }

    public TerminalExistsException(TerminalModel existingTerminal, TerminalModel incomingTerminal)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    public TerminalExistsException(string? message, TerminalModel existingTerminal, TerminalModel incomingTerminal) : base(message)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    public TerminalExistsException(string? message, Exception? innerException, TerminalModel existingTerminal, TerminalModel incomingTerminal) : base(message, innerException)
    {
        ExistingTerminal = existingTerminal;
        IncomingTerminal = incomingTerminal;
    }

    protected TerminalExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
