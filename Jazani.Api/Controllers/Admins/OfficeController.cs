using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class OfficeController : Controller
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeController(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Office>> Get()
        {
            return await _officeRepository.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Office> Get(int id)
        {
            return await _officeRepository.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

