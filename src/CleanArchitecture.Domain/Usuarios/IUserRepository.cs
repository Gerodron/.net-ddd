using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Usuarios
{
    public interface IUserRepository
    {
        Task<User> GetByIdAysnc(Guid id, CancellationToken cancellationToken = default);

        void Add(User user);    
    }
}
