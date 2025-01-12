using System.Configuration;
using System.Data;
using System.Windows;
using ffa_tool.Models;
using ffa_tool.ViewModels;

namespace ffa_tool;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Airport airport;

    public App()
    {
        airport = new();
        airport.Name = "London Heathrow";
        airport.AirportId = 1;
        airport.Code = "LHR";
        
        var terminal2 = new Terminal() { TerminalId = 1, Name = "Terminal 2" };
        var terminal3 = new Terminal() { TerminalId = 2, Name = "Terminal 3" };
        var terminal4 = new Terminal() { TerminalId = 3, Name = "Terminal 4" };
        var terminal5 = new Terminal() { TerminalId = 4, Name = "Terminal 5" };

        airport.AddTerminal(terminal2);
        airport.AddTerminal(terminal3);
        airport.AddTerminal(terminal4);
        airport.AddTerminal(terminal5);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var newWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(airport)
        };

        newWindow.Show();
    }
}
