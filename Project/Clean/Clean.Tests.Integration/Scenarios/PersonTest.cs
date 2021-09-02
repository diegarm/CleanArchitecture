using Clean.Domain.Entities;
using Clean.Tests.Integration.Fixture;
using FluentAssertions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Clean.Tests.Integration.Scenarios
{
    public class PersonTest
    {
        private readonly IntegrationTestContext _testContext;

        public PersonTest()
        {
            _testContext = new IntegrationTestContext();
            ConfigPerson();
        }

        private void ConfigPerson()
        {
            var person = new Person
            {
                Id = 1,
                FirstName = "Diego Armando",
                LastName = "de Arruda Bento",
                BirthDay = new DateTime(1986, 7, 13),
                FiscalNumber = "12345678909",
                Gender = Domain.Entities.Enum.Gender.MaleEnum
            };
            
            if(_testContext.DBContext.Person.Where(c => c.Id == person.Id).Count() == 0) { 
                _testContext.DBContext.Person.AddAsync(person);
                _testContext.DBContext.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task GivePerson_WhenGet_ThenReturnOkResponse()
        {
            //Given and When
            var response = await _testContext.Client.GetAsync("/api/person");
            var test = await response.Content.ReadAsStringAsync();

            //Then
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);                
        }


        [Fact]
        public async Task GivePerson_WhenGetPersonWithId_ThenReturnOkResponse()
        {
            //Given and When
            var response = await _testContext.Client.GetAsync("/api/person/1");

            //Then
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task GivePerson_WhenGetPersonWithId_ThenReturnNotFoundResponse()
        {
            //Given and When
            var response = await _testContext.Client.GetAsync("/api/person/999");

            //Then
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
