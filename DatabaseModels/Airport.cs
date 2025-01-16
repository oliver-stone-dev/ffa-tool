using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ffa_tool.DatabaseModels;

public class Airport
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Website { get; set; }
    public string? Country { get; set; }
    public ICollection<Terminal> Terminals { get; } = new List<Terminal>();
}
