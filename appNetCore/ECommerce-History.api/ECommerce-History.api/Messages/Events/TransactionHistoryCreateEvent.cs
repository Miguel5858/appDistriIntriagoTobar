/*using appDist.Event.MQ.Src.Events;*/
using ECommerce_History.api.Dto;
using POLYGLOT.Cross.Event.Src.Events;

namespace ECommerce_History.api.Messages.Events
{
    public class TransactionHistoryCreateEvent : Event
    {

        public CategoryDto CaterogiaParamDto { get; set; }


        public TransactionHistoryCreateEvent(CategoryDto caterogiaParametroDto) {

            CaterogiaParamDto = caterogiaParametroDto;
        }
    }
}
