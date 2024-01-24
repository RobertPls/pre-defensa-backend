using Application.Utils;
using Domain.Repositories.Accounts;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Empleados.AccesoDenegado
{
    public class AccesoDenegadoHandler : IRequestHandler<AccesoDenegadoCommand, Result>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccesoDenegadoHandler(IEmpleadoRepository empleadoRepository, IUnitOfWork unitOfWort)
        {
            _empleadoRepository = empleadoRepository;
            _unitOfWork = unitOfWort;
        }

        public async Task<Result> Handle(AccesoDenegadoCommand request, CancellationToken cancellationToken)
        {

            var empleado = await _empleadoRepository.FindByIdAsync(request.EmpleadoId);

            if (empleado == null) return new Result(false, "User not found");

            empleado.Notificar(Domain.Models.TipoNotificacion.AccesoDenegado);

            await _empleadoRepository.UpdateAsync(empleado);

            await _unitOfWork.Commit();

            return new Result(true, "Acceso a empleado denegado.");

        }
    }
}
