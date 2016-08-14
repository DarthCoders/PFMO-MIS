using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMO.Logic.Interface
{
    public interface IPFMOAsync<T> where T :class
    {
        Task<List<T>> ToListAsync();
        Task<T> FindAsync(Guid id);
        Task SaveChangesAsync(T record);
        Task Remove(T record);
        void Dispose(bool disposing);
    }
}