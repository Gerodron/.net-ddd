using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Usuarios.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Usuarios
{
    public sealed class User : Entity
    {
        private User(Guid id, Nombre nombre, Apellido apellido, Email email) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }
        public Nombre? Nombre { get; private set; }

        public Apellido? Apellido { get; private set; }

        public Email? Email { get; private set; }

        public static User Create(Guid id, Nombre nombre, Apellido apellido, Email email)
        {
            User user = new(Guid.NewGuid(), nombre, apellido, email);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }
    }
}
