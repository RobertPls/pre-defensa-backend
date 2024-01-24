using Application.Utils;
using MediatR;

namespace Application.UseCase.Command.Empleados.Sobrecarga
{
    public record SobrecargaCommand : IRequest<Result>
    {
        public Guid EmpleadoId { get; set; }


        public SobrecargaCommand()
        {

        }
    }
}
