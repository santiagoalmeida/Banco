using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces;
using Banco.Core.Interfaces.Services;

namespace Banco.Services
{
    public class MovimientosService : IMovimientosService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovimientosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Movimiento entity)
        {
            await _unitOfWork.Movimientos.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Movimiento entity)
        {
            entity = await _unitOfWork.Movimientos.GetByIdAsync(entity.IdMovimiento);
            _unitOfWork.Movimientos.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync() => await _unitOfWork.Movimientos.GetAllAsync();
        public async Task<Movimiento> GetByIdAsync(int id) => await _unitOfWork.Movimientos.GetByIdAsync(id);

        public async Task UpdateAsync(Movimiento entity)
        {
            _unitOfWork.Movimientos.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
