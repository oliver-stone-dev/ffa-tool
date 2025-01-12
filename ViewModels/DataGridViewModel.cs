using ffa_tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.ViewModels;

public class DataGridViewModel : ViewModelBase
{
    public string Name { get; init; }

    public bool ReadOnly { get; init; }

    private string? _value;

    public string Value 
    {
        get => _value!;
        set
        {
            if (ReadOnly) return;
            _value = value;
            OnPropertyChanged(nameof(Value));   
        }
    }

    public DataGridViewModel(string Name, string Value, bool ReadOnly)
    {
        this.ReadOnly = ReadOnly;
        this.Name = Name;
        _value = Value;
    }
}
