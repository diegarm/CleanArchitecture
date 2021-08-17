using AutoMapper;
using Clean.Application.Interfaces;
using Clean.Application.ViewModels;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;

        }

        public void Add<PersonViewModel>(PersonViewModel person) where PersonViewModel : class
        {
            var mapPerson = _mapper.Map<Person>(person);
            _personRepository.Add(person);
        }

        public void Update<PersonViewModel>(PersonViewModel person) where PersonViewModel : class
        {
            var mapPerson = _mapper.Map<Person>(person);
            _personRepository.Update(person);
        }

        public void Delete<PersonViewModel>(PersonViewModel person) where PersonViewModel : class
        {
            var mapPerson = _mapper.Map<Person>(person);
            _personRepository.Delete(person);
        }
        public Task<bool> SaveChangesAsync()
        {
            return _personRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<PersonViewModel>> GetAllPersonAsync()
        {
            var result = await _personRepository.GetAllPersonAsync();
            return _mapper.Map<IEnumerable<PersonViewModel>>(result);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllPersonByNameAsync(string name)
        {
            var result = await _personRepository.GetAllPersonByNameAsync(name);
            return _mapper.Map<IEnumerable<PersonViewModel>>(result);
        }

    }
}
