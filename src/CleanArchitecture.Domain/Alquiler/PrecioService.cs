using CleanArchitecture.Domain.vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Alquiler
{
    public sealed class PrecioService
    {
        public PrecioDetalle CalcularPrecio(Vechiculo vehiculo, DateRange periodo)
        {
            var tipoMoneda = vehiculo.Precio!.TipoMoneda;
            var precioPorPeriodo = new Moneda(
                vehiculo.Precio.Monto * periodo.CantidadDias,
                vehiculo.Precio.TipoMoneda
                );

            decimal porcentageChange = 0;

            foreach(var acessorios in vehiculo.Accesorios)
            {
                porcentageChange += acessorios switch
                {
                    Accesorios.AppleCar or Accesorios.AndroidCar => 0.05m,
                    Accesorios.AireAcondicionado => 0.01m,
                    Accesorios.Mapas => 0.01m,
                    _ => 0
                }; ;
            }

            var accesoriosCharges = Moneda.Zero(tipoMoneda);
            if(porcentageChange > 0)
            {
                accesoriosCharges = new Moneda(
                    precioPorPeriodo.Monto * porcentageChange
                    , tipoMoneda);

            }

            var precioTotal = Moneda.Zero();

            precioTotal += precioPorPeriodo;

                if (!vehiculo!.Mantenimiento!.IsZero())
                {
                    precioTotal += vehiculo.Mantenimiento;
                }

            precioTotal += accesoriosCharges;

            return new PrecioDetalle(
                precioPorPeriodo, 
                vehiculo.Mantenimiento, 
                accesoriosCharges, 
                precioTotal);
        }


    }
}
