using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ffa_tool.Commands;
using ffa_tool.Models;

namespace ffa_tool.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public AirportSearchViewModel AirportSearchViewModel { get; init; }
    public AirportDataViewModel AirportDataViewModel { get; init; }
    public TerminalDataViewModel TerminalDataViewModel { get; init; }
    public ControlButtonsViewModel ControlButtonsViewModel { get; init; }

    public MainWindowViewModel(Airport airport)
    {
        AirportDataViewModel = new(airport);
        AirportSearchViewModel = new(airport);
        TerminalDataViewModel = new(airport);
        ControlButtonsViewModel = new();
    }
}
