using Infrastructure.EntityFramework.ReadModel.Empleados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Empleados
{
    internal class EmpleadoReadConfig : IEntityTypeConfiguration<EmpleadoReadModel>
    {
        public void Configure(EntityTypeBuilder<EmpleadoReadModel> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Apellidop).HasColumnName("apellidop");
            builder.Property(x => x.Apellidom).HasColumnName("apellidom");
        }
    }
}
