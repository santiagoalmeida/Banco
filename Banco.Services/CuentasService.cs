using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces;
using Banco.Core.Interfaces.Services;

namespace Banco.Services
{
    public class CuentasService : ICuentasService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CuentasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Cuenta entity)
        {
            await _unitOfWork.Cuentas.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Cuenta entity)
        {
            entity = await _unitOfWork.Cuentas.GetByIdAsync(entity.NumeroCuenta);
            _unitOfWork.Cuentas.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetAllAsync() => await _unitOfWork.Cuentas.GetAllCuentasAsync();
        public async Task<Cuenta> GetByIdAsync(int id) => await _unitOfWork.Cuentas.GetByIdAsync(id);

        public async Task UpdateAsync(Cuenta entity)
        {
            _unitOfWork.Cuentas.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
