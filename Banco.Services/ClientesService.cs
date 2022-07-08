using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces;
using Banco.Core.Interfaces.Services;

namespace Banco.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Cliente entity)
        {
            await _unitOfWork.Clientes.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Cliente entity)
        {
            entity = await _unitOfWork.Clientes.GetByIdAsync(entity.IdCliente);
            _unitOfWork.Clientes.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _unitOfWork.Clientes.GetAllAsync();
        public async Task<Cliente> GetByIdAsync(int id) => await _unitOfWork.Clientes.GetByIdAsync(id);

        public async Task UpdateAsync(Cliente entity)
        {
            _unitOfWork.Clientes.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
