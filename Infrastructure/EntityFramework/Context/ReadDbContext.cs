using Infrastructure.EntityFramework.Config.ReadConfig.Empleados;
using Infrastructure.EntityFramework.ReadModel.Empleados;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<EmpleadoReadModel> Empleado { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpleadoReadConfig());

        }
    }
}
