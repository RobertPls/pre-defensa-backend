using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Empleados
{
    internal class EmpleadoReadModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }

    }
}
