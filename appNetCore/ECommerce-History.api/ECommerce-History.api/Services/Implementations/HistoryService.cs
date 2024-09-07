using ECommerce_History.api.Dto;
using ECommerce_History.api.Models;
using ECommerce_History.api.Persistences;
using ECommerce_History.api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECommerce_History.api.Services.Implementations
{
    public class HistoryService : IHistoryService
    {

        private readonly ContextDatabase context;

        public HistoryService(ContextDatabase context) => this.context = context;

        public async Task<string> CreateAsync(CategoryDto categoryDto)
        {
            HistoryModel historyModel = new();
            historyModel.Name = categoryDto.Name!;
            historyModel.Description = categoryDto.Description!;
            historyModel.NameTable = "Category";
            historyModel.NameTablaFK = categoryDto.Id;
            historyModel.UnitPrice = 0;
            historyModel.Url = "historyservice";


            await context.Histories.AddAsync(historyModel);
            context.Entry(historyModel).State = EntityState.Added;
            await context.SaveChangesAsync();

            return historyModel.Id.ToString();
        }

        public async Task<List<CategoryHistoryDto>> ListAsync()
        {

            List<HistoryModel> historLista = await context.Histories.ToListAsync();

            var lista  = historLista.Select(h => new CategoryHistoryDto { 
                Name = h.Name,
                Description = h.Description
            }).ToList();

            return lista;
            
        }
    }
}
