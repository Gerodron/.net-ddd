using CleanArchitecture.Domain.vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Alquiler
{
    public record PrecioDetalle(
        Moneda PrecioPorPeriodo,
        Moneda Mantenimiento,
        Moneda Accesorios,
        Moneda PrecioTotal
        );
}
