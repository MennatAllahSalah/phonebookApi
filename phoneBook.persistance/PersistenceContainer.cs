using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using phoneBook.Application.interfaces;
using phoneBook.persistance.Reprosatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.persistance
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<phoneDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PhoneConnectionString")));

            services.AddScoped(typeof(IPhoneBookReprosatory), typeof(phoneReprosatory));
         

            return services;
        }
    }
}
