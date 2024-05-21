using Microsoft.EntityFrameworkCore;
using System;

namespace SysGeSeApp2024.Data
{
    public class SysGeseDbContext : DbContext
    {
        public SysGeseDbContext(DbContextOptions<SysGeseDbContext> options) : base(options) { }

        public DbSet<Funcao> Funcoes { get; set; }
    }
}
