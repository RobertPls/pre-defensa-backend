using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Empleados
{
    internal class EmpleadoWriteConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Apellidop).HasColumnName("apellidop");
            builder.Property(x => x.Apellidom).HasColumnName("apellidom");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
