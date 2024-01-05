using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        public static List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid id) => Id = id;

        public Guid Id { get; init; }

        protected void RaiseDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);  
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents ()
        {
            return _domainEvents.ToList();
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();  
        }

    }
}
