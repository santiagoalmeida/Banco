using Banco.Core.Constantes;
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
            try
            {
                await _unitOfWork.Cuentas.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.Movimientos.AddAsync(new Movimiento
                {
                    NumeroCuenta = entity.NumeroCuenta,
                    Fecha = DateTime.Now,
                    TipoMovimiento = TipoMovimiento.Deposito,
                    Valor = entity.SaldoInicial
                });
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }

        public async Task DeleteAsync(Cuenta entity)
        {
            try
            {
                entity = await _unitOfWork.Cuentas.GetByIdAsync(entity.NumeroCuenta);
                _unitOfWork.Cuentas.Remove(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public async Task<IEnumerable<Cuenta>> GetAllAsync()
        {
            IEnumerable<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                cuentas = await _unitOfWork.Cuentas.GetAllCuentasAsync();
            }
            catch (Exception ex)
            {
                //log
            }
            return cuentas;
        }
        public async Task<Cuenta> GetByIdAsync(Cuenta entity)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                cuenta = await _unitOfWork.Cuentas.GetByIdAsync(entity.NumeroCuenta);
            }
            catch (Exception ex)
            {
                //log
            }
            return cuenta;
        }

        public async Task UpdateAsync(Cuenta entity)
        {
            try
            {
                Cuenta cta = await _unitOfWork.Cuentas.GetByIdAsync(entity.NumeroCuenta);
                cta.TipoCuenta = entity.TipoCuenta;
                cta.IdCliente = entity.IdCliente;
                cta.Estado = entity.Estado;
                cta.SaldoInicial = entity.SaldoInicial;

                _unitOfWork.Cuentas.Update(cta);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }
}
