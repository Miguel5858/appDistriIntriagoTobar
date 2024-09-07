using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using ECommerceAPI.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<ProductDto>> GetAsync(string id);

        Task<ProductDtoCollectionResponse> ListAsync();

        Task<BaseResponse<string>> CreateAsync(ProductRequest request);

        Task<BaseResponse<string>> UpdateAsync(string id, ProductRequest request);

        Task<BaseResponse<string>> DeleteAsync(string id);
    }
}
