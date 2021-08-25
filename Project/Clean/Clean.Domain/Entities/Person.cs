using Clean.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clean.Domain.Entities
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string FiscalNumber { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

    }
}
