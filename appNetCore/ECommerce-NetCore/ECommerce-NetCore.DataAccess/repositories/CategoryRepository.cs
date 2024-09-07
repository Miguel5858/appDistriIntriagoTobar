using Azure;
using ECommerce_NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public class CategoryRepository : ECommerceRepositoryGeneric<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceNetCoreDbContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Category entity)
        {
            return await Insert(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await DeleteEntity(id);
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await Select(id);
        }

        public async Task<(ICollection<Category> categoryLista, int total)> ListAsync()
        {
            var categoryLista = await SelectAll();
            int total = 0;
            if (categoryLista != null)
            {

                total = categoryLista.Count;
            }

            return (categoryLista, total);
        }

        public async Task UpdateAsync(Category entity)
        {
            await UpdateEntity(entity);
        }

    }
}
