using ECommerce_NetCore.DataAccess.repositories;
using ECommerce_NetCore.Dto.Response;
using ECommerce_NetCore.Entities;
using ECommerce_NetCore.Services.Interfaces;
using ECommerceAPI.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository productService)
        {
            _repository = productService;
        }

        public async Task<BaseResponse<string>> CreateAsync(ProductRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                Product productEntity = new();
                productEntity.Name = request.Name;
                productEntity.Description = request.Description;
                productEntity.CategoryId = request.CategoryId;
                productEntity.UnitPrice = request.UnitPrice;
                productEntity.ProductUrl = request.FileName;
                productEntity.Active = request.Active;

                response.Result = await _repository.CreateAsync(productEntity);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<string>> DeleteAsync(string id)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _repository.DeleteAsync(id);
                response.Result = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = "Error";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<BaseResponse<ProductDto>> GetAsync(string id)
        {
            var response = new BaseResponse<ProductDto>();
            try
            {
                var product = await _repository.GetItemAsync(id);
                if (product == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                ProductDto productDto = new();
                productDto.Id = product.Id;
                productDto.Name = product.Name!;
                productDto.Description = product.Description!;

                response.Result = productDto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ProductDtoCollectionResponse> ListAsync()
        {
            var response = new ProductDtoCollectionResponse();
            try
            {
                var result = await _repository.ListAsync();

                response.Collection = result.productoLista.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Url = p.ProductUrl

                }).ToList();

                response.TotalPages = result.total;

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<string>> UpdateAsync(string id, ProductRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                Product producto = new();
                producto.Id = id;
                producto.Name = request.Name;
                producto.Description = request.Description;
                producto.CategoryId = request.CategoryId;
                producto.UnitPrice = request.UnitPrice;
                producto.ProductUrl = request.FileName;
                producto.Active = request.Active;

                await _repository.UpdateAsync(producto);

                response.Result = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
