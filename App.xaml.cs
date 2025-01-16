using System.Configuration;
using System.Data;
using System.Windows;
using ffa_tool.DomainModels;
using ffa_tool.Services;
using ffa_tool.ViewModels;

namespace ffa_tool;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IAirportService _airportService;
    private AirportModel _airportModel;
    private AirportManagerModel _airportManager;

    public App()
    {
        _airportService = new AirportService();
        _airportModel = new AirportModel();
        _airportManager = new(_airportModel, _airportService);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var newWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(_airportManager,_airportModel)
        };

        newWindow.Show();
    }
}
