using Clean.Domain.Entities;
using Clean.Tests.Integration.Fixture;
using FluentAssertions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;
using System.Text.Json;
using System.Net.Http;
using System.Text;

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


        [Fact]
        public async Task GiveNewPerson_WhenPostPerson_ThenReturnOKResponseAndGetPerson()
        {
            //Given
            
                //Count Persons
                var responseGet = await _testContext.Client.GetAsync("/api/person/$count").ConfigureAwait(false);
                responseGet.EnsureSuccessStatusCode();
                var resultGetCount = await responseGet.Content.ReadAsStringAsync().ConfigureAwait(false);

                //New Person
                var newPerson = new Person
                {
                    FirstName = "Edson",
                    LastName = "Arantes",
                    FiscalNumber = "12345677",
                    BirthDay = new DateTime(1988, 07, 14),
                    Gender = Domain.Entities.Enum.Gender.MaleEnum
                };
            
                string newPersonJson = JsonSerializer.Serialize(newPerson);     
                var requestContent = new StringContent(newPersonJson, Encoding.UTF8, "application/json");

            //When
                var responseNewPerson = await _testContext.Client.PostAsync("/api/person/", requestContent).ConfigureAwait(false);

                //Count Persons
                var responseGetNew = await _testContext.Client.GetAsync("/api/person/$count").ConfigureAwait(false);
                responseGetNew.EnsureSuccessStatusCode();
                var resultGetCountNew = await responseGetNew.Content.ReadAsStringAsync().ConfigureAwait(false);


            //Then
                responseNewPerson.StatusCode.Should().Be(HttpStatusCode.OK);
                Assert.True(long.Parse(resultGetCountNew) > long.Parse(resultGetCount));
        }

    }
}
