using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Data.EntityFramework.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();


            //Create example in Table
           /*builder.HasData(new Person
            {
                Id = 999,
                FirstName = "Diego Armando",
                LastName = "de Arruda Bento",
                BirthDay = DateTime.Parse("13/07/1986"),
                FiscalNumber = "34801267823",
                Gender = Domain.Entities.Enum.Gender.MaleEnum
            });*/
        }
    }
}
