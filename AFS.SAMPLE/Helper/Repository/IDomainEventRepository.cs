using AFS.SAMPLE.Helper.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFS.SAMPLE.Helper.Repository
{
    public interface IDomainEventRepository
    {
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
        IEnumerable<DomainEventRecord> FindAll();
    }
}
