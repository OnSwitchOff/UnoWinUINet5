using HarabaSourceGenerators.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnoWinUINet5.Infrastructure
{
    [Inject]
    public partial class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly MediatR.IMediator _mediator;
        private readonly IDomainEventsProvider _domainEventsProvider;

        public async System.Threading.Tasks.Task DispatchEventsAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            var domainEvents = _domainEventsProvider.GetAllDomainEvents();
            _domainEventsProvider.ClearAllDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
