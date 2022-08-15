using Microsoft.EntityFrameworkCore;
using phoneBook.Application.interfaces;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace phoneBook.persistance.Reprosatories
{
    public class phoneReprosatory : IPhoneBookReprosatory
    {
        protected readonly phoneDbContext _dbContext;

        public phoneReprosatory(phoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BookPhone> Add(BookPhone item)
        {
            await _dbContext.phone.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task delete(BookPhone item)
        {
            _dbContext.phone.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<IReadOnlyList<BookPhone>> GetAl()
        {
           
            return await _dbContext.phone.ToListAsync(); 
        }

        public Task<BookPhone> GetById(int id)
        {
           
          return _dbContext.phone.FirstOrDefaultAsync(b => b.Id == id);
          
        }

        public async Task update(BookPhone item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
