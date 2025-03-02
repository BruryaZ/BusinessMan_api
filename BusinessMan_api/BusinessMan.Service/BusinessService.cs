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
    // TODO: Implement the UserService class
    public class BusinessService(IRepositoryManager repositoryManager) : IService<Business>
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        public async Task<Business?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Business.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Business>> GetListAsync()
        {
            return await _repositoryManager.Business.GetAllAsync();
        }
        public async Task<Business> AddAsync(Business business)
        {
            return await _repositoryManager.Business.AddAsync(business);
        }
        public async Task DeleteAsync(Business business)
        {
            await _repositoryManager.Business.DeleteAsync(business);
        }
        public async Task<Business?> UpdateAsync(int id, Business item)
        {
            return await _repositoryManager.Business.UpdateAsync(id, item);
        }
    }
}