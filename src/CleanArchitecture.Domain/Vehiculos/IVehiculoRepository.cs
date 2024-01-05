using CleanArchitecture.Domain.vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Vehiculos
{
    public interface IVehiculoRepository
    {
        Task<Vechiculo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default );

        void Add(Vechiculo vechiculo);
    }
}
