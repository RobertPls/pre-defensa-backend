using Domain.Models;

namespace Domain.Factories
{
    public class EmpleadoFactory : IEmpleadoFactory
    {
        public Empleado Create(string name, string apellidop, string apellidom)
        {
            return new Empleado(name, apellidop, apellidom);
        }
    }
}
