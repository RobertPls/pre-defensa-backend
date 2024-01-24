using Domain.Models;
using Domain.Repositories.Accounts;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.TiposProyectos
{
    internal class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly WriteDbContext _context;

        public EmpleadoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Empleado obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Empleado?> FindByIdAsync(Guid id)
        {
            return await _context.Empleado.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Empleado obj)
        {
            _context.Empleado.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Empleado obj)
        {
            _context.Empleado.Update(obj);
            return Task.CompletedTask;
        }

    }
}
