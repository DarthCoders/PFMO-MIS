using PFMO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMO.Logic.Interface
{
    public interface IPFMO<T> where T : class
    {
        List<T> GetList();
        T Find(Guid id);
        void Save(T record);
        void Delete(T record);
        void Dispose(bool disposing);
    }
}