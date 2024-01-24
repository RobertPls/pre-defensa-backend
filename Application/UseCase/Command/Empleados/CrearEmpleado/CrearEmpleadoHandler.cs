using Application.UseCase.Command.Empleados.CrearEmpleado;
using Application.Utils;
using Domain.Factories;
using Domain.Repositories.Accounts;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Empleados.CreateEmpleado
{
    public class CrearEmpleadoHandler : IRequestHandler<CrearEmpleadoCommand, Result>
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEmpleadoFactory _empleadoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearEmpleadoHandler(IEmpleadoRepository empleadoRepository, IEmpleadoFactory empleadoFactory, IUnitOfWork unitOfWort)
        {
            _empleadoRepository = empleadoRepository;
            _empleadoFactory = empleadoFactory;
            _unitOfWork = unitOfWort;
        }

        public async Task<Result> Handle(CrearEmpleadoCommand request, CancellationToken cancellationToken)
        {

            var empleado = _empleadoFactory.Create(request.Nombre,request.Apellidop,request.Apellidom);

            await _empleadoRepository.CreateAsync(empleado);

            await _unitOfWork.Commit();

            return new Result(true, "Empleado created successfully.");

        }
    }
}
