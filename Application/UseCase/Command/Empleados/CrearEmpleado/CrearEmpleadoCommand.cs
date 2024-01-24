using Application.Utils;
using MediatR;

namespace Application.UseCase.Command.Empleados.CrearEmpleado
{
    public record CrearEmpleadoCommand : IRequest<Result>
    {
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }

        public CrearEmpleadoCommand(string nombre, string apellidop, string apellidom)
        {
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
        }
    }
}
