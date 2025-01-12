using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ffa_tool.ViewModels;

public class ControlButtonsViewModel : ViewModelBase
{
    public ICommand DeleteAirportCommand { get; }
    public ICommand UploadChangesCommand { get; }
}
