using ffa_tool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.ViewModels;

public class TerminalDataViewModel : ViewModelBase
{
    private readonly Airport _airport;

    private readonly ObservableCollection<DataGridViewModelItem<Terminal>> _selectedTerminalInfo;
    public IEnumerable<DataGridViewModelItem<Terminal>> SelectedTerminalInfo => _selectedTerminalInfo;

    private readonly ObservableCollection<string> _terminalNames;
    public IEnumerable<string> TerminalNames => _terminalNames;

    private string? _selectedTerminalName;

    public string? SelectedTerminalName
    {
        get => _selectedTerminalName;

        set
        {
            _selectedTerminalName = value;
            OnPropertyChanged(nameof(SelectedTerminalName));
            SetTerminalInfo(_selectedTerminalName!);
        }
    }

    public TerminalDataViewModel(Airport airport)
    {
        _airport = airport;
        _selectedTerminalInfo = new ObservableCollection<DataGridViewModelItem<Terminal>>();
        _terminalNames = new ObservableCollection<string>();

        AddTerminalNamesToCombo();
    }

    public void SetTerminalInfo(string name)
    {
        if (string.IsNullOrEmpty(name)) return;

        var terminal = _airport.GetTerminalByName(name);

        if (terminal == null) return;

        _selectedTerminalInfo.Clear();
    }

    private void AddTerminalNamesToCombo()
    {
        foreach (var terminal in _airport.Terminals)
        {
            if (string.IsNullOrEmpty(terminal.Name)) continue;
            _terminalNames.Add(terminal.Name);
        }
    }
}
