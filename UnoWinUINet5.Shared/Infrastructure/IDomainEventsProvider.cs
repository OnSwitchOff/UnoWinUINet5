using DataBase.Events;
using System.Collections.Generic;

namespace UnoWinUINet5.Infrastructure
{
    public interface IDomainEventsProvider
    {
        IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}
