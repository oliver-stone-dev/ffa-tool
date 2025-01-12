using ffa_tool.Commands;
using ffa_tool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.ViewModels;

public class AirportSearchViewModel : ViewModelBase
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

    public AirportSearchViewModel(Airport airport)
    {
        _airport = airport;
        SearchCommand = new AirportSearchCommand(this,airport);
    }

    public ICommand SearchCommand { get; }

    public ICommand AddCommand { get; }
}
