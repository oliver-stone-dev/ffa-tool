﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.Commands;

namespace ffa_tool.Commands;

public class AirportSearchCommand : CommandBase
{
    public override bool CanExecute(object? parameter)
    {
        return base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        Trace.WriteLine("Searching!");
    }
}