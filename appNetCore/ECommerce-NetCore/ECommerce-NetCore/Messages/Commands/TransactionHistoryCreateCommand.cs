using appDist.Event.MQ.Src.Commands;
using ECommerce_NetCore.Dto.Response;

namespace ECommerce_NetCore.Messages.Commands
{
    public class TransactionHistoryCreateCommand : Command
    {
        public CategoryDto CaterogiaParamDto { get; set; }

        public TransactionHistoryCreateCommand(CategoryDto caterogiaParametroDto)
        {
            CaterogiaParamDto = caterogiaParametroDto;
        }

    }
}
