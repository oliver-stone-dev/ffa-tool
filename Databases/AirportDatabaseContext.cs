using ffa_tool.DatabaseModels;
using ffa_tool.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffa_tool.Databases;

public class AirportDatabaseContext : DbContext
{
    public DbSet<Airport> Airports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = DatabaseSettingsReader.ReadSetting("ConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
