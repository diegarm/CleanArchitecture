using Clean.Domain.Entities.Enum;
using System;

namespace Clean.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string FiscalNumber { get; set; }
        public DateTime BirthDay { get; set; }

        public Gender Gender { get; set; }

    }
}
