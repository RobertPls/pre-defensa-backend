using Application.Dto;
using Application.UseCase.Query.Accounts.GetAccountListByUserId;
using Application.Utils;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Empleados;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Empleados
{
    internal class GetListaEmpleadosHandler : IRequestHandler<GetListaEmpleadoQuery, Result<IEnumerable<EmpleadoDto>>>
    {
        private readonly DbSet<EmpleadoReadModel> empleado;
        public GetListaEmpleadosHandler(ReadDbContext dbContext)
        {
            empleado = dbContext.Empleado;
        }
        public async Task<Result<IEnumerable<EmpleadoDto>>> Handle(GetListaEmpleadoQuery request, CancellationToken cancellationToken)
        {
            var query = empleado.AsNoTracking().AsQueryable();

            var lista = await query.Select(empleado => new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellidop = empleado.Apellidop, 
                Apellidom = empleado.Apellidom,
            }).ToListAsync();

            return new Result<IEnumerable<EmpleadoDto>>(lista, true);
        }
    }
}
