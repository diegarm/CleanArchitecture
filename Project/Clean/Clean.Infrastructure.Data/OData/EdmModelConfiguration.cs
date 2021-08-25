using Clean.Application.ViewModels;
using Clean.Domain.Entities;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Clean.Infrastructure.Data.OData
{
    public static class EdmModelConfiguration 
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<PersonViewModel>("person");
            return builder.GetEdmModel();            
        }

    }
}
