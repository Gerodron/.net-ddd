﻿using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Alquiler.Event
{
    public sealed record AlquilerReservadoDomainEvent(Guid Id) : IDomainEvent;
}
