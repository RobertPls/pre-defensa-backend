using Application.Utils;
using MediatR;

namespace Application.UseCase.Command.Empleados.Ausencia
{
    public record AusenciaCommand : IRequest<Result>
    {
        public Guid EmpleadoId { get; set; }


        public AusenciaCommand()
        {

        }
    }
}
