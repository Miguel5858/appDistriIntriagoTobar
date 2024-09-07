using ECommerce_History.api.Dto;
using ECommerce_History.api.Messages.Events;
using ECommerce_History.api.Services.Interfaces;
using POLYGLOT.Cross.Event.Src.Bus;

namespace ECommerce_History.api.Messages.EventHandlers;
public class TransactionEventHandler : IEventHandler<TransactionHistoryCreateEvent>
{
    public readonly IHistoryService _historyService;
    public TransactionEventHandler(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    public Task Handle(TransactionHistoryCreateEvent @event)
    {
        var dataDto = @event.CaterogiaParamDto;
        Console.WriteLine(dataDto.Name);
        _historyService.CreateAsync(dataDto);
        return Task.CompletedTask;
    }
}

