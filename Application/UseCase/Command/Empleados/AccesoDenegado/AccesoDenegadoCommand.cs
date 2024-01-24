using Application.Utils;
using MediatR;

namespace Application.UseCase.Command.Empleados.AccesoDenegado
{
    public record AccesoDenegadoCommand : IRequest<Result>
    {
        public Guid EmpleadoId { get; set; }


        public AccesoDenegadoCommand()
        {

        }
    }
}
