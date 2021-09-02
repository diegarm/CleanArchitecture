using Clean.Application.Interfaces;
using Clean.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Newtonsoft.Json;
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
        [EnableQuery(PageSize = 5)]
        [HttpGet("/api/person")]
        [HttpGet("/api/person/$count")]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllPersonAsync();
            return Ok(result);            
        }


        [HttpGet("/api/person/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personService.GetPersonByIdAsync(id).ConfigureAwait(false);

            if (result is null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("/api/person/")]
        public async Task<IActionResult> PostAsync([FromBody] object obj)
        {
            var personViewModel = JsonConvert.DeserializeObject<PersonViewModel>(obj.ToString());

            var result = await _personService.Add<PersonViewModel>(personViewModel).ConfigureAwait(false);
            return Ok(result);
        }


        [HttpPut("/api/person/{id}")]
        public async Task<IActionResult> PutAsync(PersonViewModel personViewModel)
        {
            var result = await _personService.Update<PersonViewModel>(personViewModel).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
