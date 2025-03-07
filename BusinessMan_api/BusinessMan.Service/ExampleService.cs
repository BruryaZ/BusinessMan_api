using BusinessMan.Core.Models;
using BusinessMan.Core.Services;
using BusinessMan.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMan.Service
{
    // TODO: Implement the ExampleService class
    public class ExampleService(IRepositoryManager repositoryManager) : IService<Example>
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        public async Task<Example?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Examples.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Example>> GetListAsync()
        {
            return await _repositoryManager.Examples.GetAllAsync();
        }
        public async Task<Example> AddAsync(Example Example)
        {
            return await _repositoryManager.Examples.AddAsync(Example);
        }
        public async Task DeleteAsync(Example item)
        {
            await _repositoryManager.Examples.DeleteAsync(item);
        }
        public async Task<Example?> UpdateAsync(int id, Example item)
        {
            return await _repositoryManager.Examples.UpdateAsync(id, item);
        }
    }
}