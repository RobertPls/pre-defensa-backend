using Domain.Models;

namespace Domain.Factories
{
    public interface IEmpleadoFactory
    {
        Empleado Create(string name, string apellidop, string apellidom);
    }
}
