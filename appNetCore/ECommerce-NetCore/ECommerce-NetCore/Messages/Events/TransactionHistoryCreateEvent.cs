using appDist.Event.MQ.Src.Events;
using ECommerce_NetCore.Dto.Response;

namespace ECommerce_NetCore.Messages.Events
{
    public class TransactionHistoryCreateEvent : Event
    {

        public CategoryDto CaterogiaParamDto { get; set; }


        public TransactionHistoryCreateEvent(CategoryDto caterogiaParametroDto) {

            CaterogiaParamDto = caterogiaParametroDto;
        }
    }
}
