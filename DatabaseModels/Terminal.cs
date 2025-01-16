using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ffa_tool.DatabaseModels;

public class Terminal
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int AirportId { get; set; }

    public string? Name { get; set; }

    public Airport? Airport { get; set; }
}
