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
            try
            {
                await _unitOfWork.Clientes.AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                //log
            }
        }

        public async Task DeleteAsync(Cliente entity)
        {
            try
            {
                entity = await _unitOfWork.Clientes.GetByIdAsync(entity.IdCliente);
                _unitOfWork.Clientes.Remove(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            IEnumerable<Cliente> clients = new List<Cliente>();  
            try
            {
                clients =  await _unitOfWork.Clientes.GetAllAsync();
            }
            catch (Exception ex)
            {
                //log
            }
            return clients;
        }

        public async Task<Cliente> GetByIdAsync(Cliente entity)
        {
            Cliente cliente = new Cliente();
            try
            {
                cliente = await _unitOfWork.Clientes.GetByIdAsync(entity.IdCliente);
            }
            catch (Exception ex)
            {
                //log
            }
            return cliente;
        }

        public async Task UpdateAsync(Cliente entity)
        {
            try
            {
                _unitOfWork.Clientes.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }
}
