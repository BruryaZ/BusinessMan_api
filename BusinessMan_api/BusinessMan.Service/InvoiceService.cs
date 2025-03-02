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
    public class InvoiceService(IRepositoryManager repositoryManager) : IService<Invoice>
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Invoice.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Invoice>> GetListAsync()
        {
            return await _repositoryManager.Invoice.GetAllAsync();
        }
        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            return await _repositoryManager.Invoice.AddAsync(invoice);
        }
        public async Task DeleteAsync(Invoice invoice)
        {
            await _repositoryManager.Invoice.DeleteAsync(invoice);
        }
        public async Task<Invoice?> UpdateAsync(int id, Invoice item)
        {
            return await _repositoryManager.Invoice.UpdateAsync(id, item);
        }
    }
}