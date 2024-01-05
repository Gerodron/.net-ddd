using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Alquiler
{
    public sealed record DateRange
    {
        private DateRange()
        {  

        }

        public DateOnly Inicio { get; init; }

        public DateOnly Fin { get; init;}

        public int CantidadDias => Fin.Day - Inicio.Day; 

        public static DateRange Create(DateOnly fec_inicio, DateOnly fec_fin)
        {
            if(fec_inicio > fec_fin)
            {
                throw new ApplicationException("La fecha de inicio es mayor que la fecha de fin");
            }

            return new DateRange
            {
                Inicio = fec_inicio,
                Fin = fec_fin,
            };

        }
    }
}
