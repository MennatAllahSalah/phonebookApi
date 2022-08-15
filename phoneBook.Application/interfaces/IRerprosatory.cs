using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Application.interfaces
{
   public interface IRerprosatory<T> where T :class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAl();
        Task<T> Add(T item);
        Task update(T item);
        Task delete(T item);
    }
}
