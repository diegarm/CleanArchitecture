using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.API.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllPersonAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personService.GetPersonByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{name}/name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _personService.GetAllPersonByNameAsync(name);
            return Ok(result);
        }

    }
}
