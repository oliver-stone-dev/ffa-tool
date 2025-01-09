using System;
using System.Collections.Generic;
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
    private readonly Airport _airport;
    private string? _searchText;

    public string? SearchText 
    {
        get => _searchText;

        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    public MainWindowViewModel(Airport airport)
    {
        _airport = airport;
        _searchText = airport.Name;
        SearchCommand = new AirportSearchCommand();
    }

    public ICommand SearchCommand { get; }

    public ICommand AddCommand { get; }
}
