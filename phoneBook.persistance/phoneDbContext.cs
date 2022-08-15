using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.persistance
{
 public class phoneDbContext : IdentityDbContext<ApplicationUser>
    {
        public phoneDbContext(DbContextOptions<phoneDbContext> options)
           : base(options)
        {
        }

        public DbSet<BookPhone> phone { get; set; }

      

        
    
    }
}
