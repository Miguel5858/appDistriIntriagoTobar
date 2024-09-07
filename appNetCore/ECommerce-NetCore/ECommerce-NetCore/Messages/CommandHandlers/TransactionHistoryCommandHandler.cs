using appDist.Event.MQ.Src.Bus;
using ECommerce_NetCore.Messages.Commands;
using ECommerce_NetCore.Messages.Events;
using MediatR;

namespace ECommerce_NetCore.Messages.CommandHandlers
{
    public class TransactionHistoryCommandHandler : IRequestHandler<TransactionHistoryCreateCommand, bool>
    {
        private readonly IEventBus _bus;


        public TransactionHistoryCommandHandler(IEventBus bus) => _bus = bus;


        public Task<bool> Handle(TransactionHistoryCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransactionHistoryCreateEvent(request.CaterogiaParamDto));

            return Task.FromResult(true);
        }
    }
}
