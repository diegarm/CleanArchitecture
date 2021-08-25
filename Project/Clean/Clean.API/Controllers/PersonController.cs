using Clean.Application.Interfaces;
using Clean.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.API.Controllers
{
    public class PersonController : ODataController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        //Exemplo Odata
        //https://localhost:44312/api/person?$select=LastName,FirstName&$filter=LastName eq 'Bento'
        [EnableQuery(PageSize = 10)]
        [HttpGet("api/person")]
        [HttpGet("api/person/$count")]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllPersonAsync();
            return Ok(result);
        }


        [HttpGet("api/person/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personService.GetPersonByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PersonViewModel personViewModel)
        {
            var result = await _personService.Add<PersonViewModel>(personViewModel);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync(PersonViewModel personViewModel)
        {
            var result = await _personService.Update<PersonViewModel>(personViewModel);
            return Ok(result);
        }
    }
}
