using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquiler.Event;
using CleanArchitecture.Domain.vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Alquiler
{
    public sealed class Alquiler : Entity
    {
        private Alquiler(
            Guid id,
            Guid userId,
            Guid vehiculoId,
            DateRange duracion,
            Moneda precioPorPeriodo,
            Moneda mantenimiento,
            Moneda accesorios,
            Moneda precioTotal,
            AlquilerStatus status,
            DateTime fechaCreacion
            ) : base(id)
        {
            UserId = userId;
            VehiculoId = vehiculoId;
            Duracion = duracion;
            PrecioPorPeriodo = precioPorPeriodo;
            Mantenimiento = mantenimiento;
            Accesorios = accesorios;
            PrecioTotal = precioTotal;
            Status = status;
            FechaCreacion = fechaCreacion;  
        }

        public Guid? UserId {  get; private set; }

        public Guid? VehiculoId {  get; private set; }

        public Moneda? PrecioPorPeriodo {  get; private set; }

        public Moneda? Mantenimiento {  get; private set; }

        public Moneda? Accesorios {  get; private set; }

        public Moneda? PrecioTotal {  get; private set; }
      
        public AlquilerStatus? Status { get; private set; }

        public DateRange? Duracion {  get; private set; }

        public DateTime? FechaCreacion {  get; private set; }

        public DateTime? FechaConfirmacion {  get; private set; }

        public DateTime? FechaDenegacion { get; private set; }

        public DateTime? FechaCompletado { get; private set; }

        public DateTime? FechaCancelado { get; private set; }

        public static Alquiler Reservear(
            Vechiculo vehiculo,
            Guid userId,
            DateRange duracion,
            DateTime fechaCreacion,
            PrecioService precioService
            
            )
        {
            var precioDetalle = precioService.CalcularPrecio(
                vehiculo,
                duracion
                );
            Alquiler alquiler = new(
                Guid.NewGuid(),
                userId,
                vehiculo.Id,
                duracion,
                precioDetalle.PrecioPorPeriodo,
                precioDetalle.Mantenimiento,
                precioDetalle.Accesorios,
                precioDetalle.PrecioTotal,
                AlquilerStatus.Reservado,
                fechaCreacion.Date
                );

            alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id));

            vehiculo.FechaUltimaAlquiler = fechaCreacion;
            return alquiler;

        }

    }
}
