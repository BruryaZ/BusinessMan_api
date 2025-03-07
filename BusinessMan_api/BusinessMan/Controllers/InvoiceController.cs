using BusinessMan.Core.Models;
using BusinessMan.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly IService<Invoice> _allInvoices;

        public InvoiceController(IService<Invoice> invoices)
        {
            _allInvoices = invoices;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAsync()
        {
            var invoices = await _allInvoices.GetListAsync();
            //var invoicesDTO = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            return Ok(invoices);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetAsync(int id)
        {
            var invoice = await _allInvoices.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();
            //return Ok(_mapper.Map<InvoiceDto>(invoice));
            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostAsync([FromBody] Invoice value)
        {
            //var invoiceDto = _mapper.Map<Invoice>(value);
            var createdInvoice = await _allInvoices.AddAsync(value);
            //return Ok(_mapper.Map<InvoiceDto>(createdInvoice));
            return Ok(createdInvoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Invoice>> PutAsync(int id, [FromBody] Invoice value)
        {
            //var updatedInvoice = await _allInvoices.UpdateAsync(id, _mapper.Map<Invoice>(value));
            var updatedInvoice = await _allInvoices.UpdateAsync(id, value);
            if (updatedInvoice == null)
            {
                return NotFound();
            }
            //return Ok(_mapper.Map<InvoiceDto>(updatedInvoice));
            return Ok(updatedInvoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var invoice = await _allInvoices.GetByIdAsync(id);
            if (invoice is null)
            {
                return NotFound();
            }
            await _allInvoices.DeleteAsync(invoice);
            return NoContent();
        }

    }
}
