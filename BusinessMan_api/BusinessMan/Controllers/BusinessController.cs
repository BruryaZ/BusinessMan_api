using BusinessMan.Core.Models;
using BusinessMan.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : Controller
    {
        private readonly IService<Business> _allBusinesses;

        public BusinessController(IService<Business> businesses)
        {
            _allBusinesses = businesses;
        }

        // GET: api/<BusinessController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetAsync()
        {
            var businesses = await _allBusinesses.GetListAsync();
            //var businessesDTO = _mapper.Map<IEnumerable<BusinessDto>>(businesses);

            return Ok(businesses);
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetAsync(int id)
        {
            var business = await _allBusinesses.GetByIdAsync(id);
            if (business == null)
                return NotFound();
            //return Ok(_mapper.Map<BusinessDto>(business));
            return Ok(business);
        }

        // POST api/<BusinessController>
        [HttpPost]
        public async Task<ActionResult<Business>> PostAsync([FromBody] Business value)
        {
            //var businessDto = _mapper.Map<Business>(value);
            var createdBusiness = await _allBusinesses.AddAsync(value);
            //return Ok(_mapper.Map<BusinessDto>(createdBusiness));
            return Ok(createdBusiness);
        }

        // PUT api/<BusinessController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Business>> PutAsync(int id, [FromBody] Business value)
        {
            //var updatedBusiness = await _allBusinesses.UpdateAsync(id, _mapper.Map<Business>(value));
            var updatedBusiness = await _allBusinesses.UpdateAsync(id, value);
            if (updatedBusiness == null)
            {
                return NotFound();
            }
            //return Ok(_mapper.Map<BusinessDto>(updatedBusiness));
            return Ok(updatedBusiness);
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var business = await _allBusinesses.GetByIdAsync(id);
            if (business is null)
            {
                return NotFound();
            }
            await _allBusinesses.DeleteAsync(business);
            return NoContent();
        }

    }
}
