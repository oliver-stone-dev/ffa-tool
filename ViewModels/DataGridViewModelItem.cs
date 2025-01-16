using ffa_tool.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.ViewModels;

public class DataGridViewModelItem<T> : ViewModelBase
{
    private readonly object _model;
    public string PropertyName { get; init; }
    public bool ReadOnly { get; init; }

    public string Value 
    {
        get => GetString();
        set
        {
            if (ReadOnly) return;
            SetString(value);
            OnPropertyChanged(nameof(Value));   
        }
    }

    public DataGridViewModelItem(Object model,string propertyName, bool ReadOnly)
    {
        PropertyName = propertyName;
        this.ReadOnly = ReadOnly;
        _model = model;
    }

    public void SetString(string str)
    {
        if (_model == null) return;
        if (PropertyName == null) return;

        var type = typeof(T);
        type.GetProperty(PropertyName)!.SetValue(_model, str);
    }

    public string GetString()
    {
        if (_model == null) return string.Empty;
        if (PropertyName == null) return string.Empty;

        var type = typeof(T);
        string value = Convert.ToString(type.GetProperty(PropertyName)!.GetValue(_model))!;

        return value;
    }
}
