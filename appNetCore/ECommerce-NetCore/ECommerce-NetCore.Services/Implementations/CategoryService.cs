using Azure;
using ECommerce_NetCore.DataAccess.repositories;
using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using ECommerce_NetCore.Entities;
using ECommerce_NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<string>> CreateAsync(CategoryRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                Category categoryEntity = new();
                categoryEntity.Name = request.Name;
                categoryEntity.Description = request.Description;

                response.Result = await _repository.CreateAsync(categoryEntity);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }


        public async Task<BaseResponse<CategoryDto>> GetAsync(string id)
        {
            var response = new BaseResponse<CategoryDto>();
            try
            {
                var category = await _repository.GetItemAsync(id);
                if (category == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<CategoryDtoCollectionResponse> ListAsync()
        {
            var response = new CategoryDtoCollectionResponse();
            try
            {
                var result = await _repository.ListAsync();

                response.Collection = result.categoryLista.Select(p => new CategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
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


        public async Task<BaseResponse<string>> UpdateAsync(string id, CategoryRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                Category category = new Category();
                category.Id = id;
                category.Name = request.Name;
                category.Description = request.Description;

                await _repository.UpdateAsync(category);

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
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


    }
}
