using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<BaseResponse<CategoryDto>> GetAsync(string id);

        Task<CategoryDtoCollectionResponse> ListAsync();

        Task<BaseResponse<string>> CreateAsync(CategoryRequest request);

        Task<BaseResponse<string>> UpdateAsync(string id, CategoryRequest request);

        Task<BaseResponse<string>> DeleteAsync(string id);

    }
}
