using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonalWeb.Models
{
    public class DatabaseContext : DbContext
    {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
            public DbSet<Message> Messages { get; set; }
    }
}


