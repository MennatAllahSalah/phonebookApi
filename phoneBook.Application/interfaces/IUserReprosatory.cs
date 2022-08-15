using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.interfaces
{
  public interface IUserReprosatory<T> where T : class
    {
        public Task<T> Register(RegisterDto registerDto);
        public  Task<T> Login(loginDto loginDto);
        public  Task<T> GenerateToke(applicationUser userModel);

    }
}
