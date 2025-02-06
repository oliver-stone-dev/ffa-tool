using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ffa_tool.DatabaseModels;

namespace ffa_tool.Databases;

public class TerminalDatabaseContext : DbContext
{
    public DbSet<Terminal> Terminals { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = DatabaseSettingsReader.ReadSetting("ConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
