using Banco.Core.Constantes;
using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Requests;
using Banco.Core.Entities.Response;
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
            try
            {
                //Validaciones

                //Los valores cuando son crédito son positivos, y los débitos son negativos. Debe 
                //almacenarse el saldo disponible en cada transacción dependiendo del tipo de movimiento. 
                //(suma o resta)
                if (entity.TipoMovimiento == TipoMovimiento.Retiro)
                    entity.Valor = Math.Abs(entity.Valor) * -1;
                else
                    entity.Valor = Math.Abs(entity.Valor);

                //Si el saldo es cero, y va a realizar una transacción débito, debe desplegar mensaje 
                //“Saldo no disponible”
                if (entity.TipoMovimiento == TipoMovimiento.Retiro)
                {
                    int saldo = await _unitOfWork.Movimientos.GetSaldo(entity.NumeroCuenta);
                    if (saldo < Math.Abs(entity.Valor))
                        throw new Exception("Saldo no disponible");
                }

                //Se debe tener un parámetro de limite diario de retiro (valor tope 1000$)
                //Si el cupo disponible ya se cumplió no debe permitir realizar un debito y debe
                //desplegar un mensaje “Cupo diario Excedido”
                if (entity.TipoMovimiento == TipoMovimiento.Retiro)
                {
                    int limite = 1000;
                    int valorDiario = await _unitOfWork.Movimientos.GetValorDiarioRetiro(entity.Fecha, entity.NumeroCuenta);
                    if (limite < (Math.Abs(valorDiario) + Math.Abs(entity.Valor)))
                        throw new Exception("Cupo diario Excedido");
                }

                await _unitOfWork.Movimientos.AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
                //log
            }
        }

        public async Task DeleteAsync(Movimiento entity)
        {
            entity = await _unitOfWork.Movimientos.GetByIdAsync(entity.IdMovimiento);
            _unitOfWork.Movimientos.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            IEnumerable<Movimiento> movimientos = new List<Movimiento>();
            try
            {
                movimientos = await _unitOfWork.Movimientos.GetAllAsync();
            }
            catch (Exception)
            {
                //log
            }
            return movimientos;
        }
        public async Task<Movimiento> GetByIdAsync(Movimiento entity)
        {
            Movimiento movimiento = new Movimiento();
            try
            {
                await _unitOfWork.Movimientos.GetByIdAsync(entity.IdMovimiento);
            }
            catch (Exception ex)
            {
                //log
            }
            return movimiento;
        }

        public async Task<IEnumerable<ConsultaMovimientosResponse>> GetQueryMovimientosAsync(ConsultaMovimientosRequest request)
        {
            return await _unitOfWork.Movimientos.GetQueryMovimientosAsync(request.IdCliente, request.Desde, request.Hasta);
        }

        public async Task UpdateAsync(Movimiento entity)
        {
            try
            {
                _unitOfWork.Movimientos.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }
}
