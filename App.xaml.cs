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
