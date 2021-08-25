using Clean.Application.ViewModels.Enum;
using System;

namespace Clean.Application.ViewModels
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

    }
}
