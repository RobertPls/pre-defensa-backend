using Domain.Models;
using SharedKernel.Core;

namespace Domain.Repositories.Accounts
{
    public interface IEmpleadoRepository : IRepository<Empleado, Guid>
    {
        Task UpdateAsync(Empleado obj);
        Task RemoveAsync(Empleado obj);
    }
}
