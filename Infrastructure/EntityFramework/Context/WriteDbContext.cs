using Domain.Models;
using Infrastructure.EntityFramework.Config.WriteConfig.Empleados;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Empleado> Empleado { get; set; }


        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpleadoWriteConfig());
        }
    }
}
