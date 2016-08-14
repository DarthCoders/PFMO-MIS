using PFMO.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMO.Entities;
using PFMO.Contexts;
using System.Data.Entity;

namespace PFMO.Logic
{
    public class SupplyCategoriesLogic : IPFMOAsync<SupplyCategory>
    {
        //Initialization
        private PFMO_DB _db;
        public SupplyCategoriesLogic(PFMO_DB db)
        {
            _db = db;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        public Task<SupplyCategory> FindAsync(Guid id)
        {
            return _db.SupplyCategories.FindAsync(id);
        }

        public Task Remove(SupplyCategory record)
        {
            _db.SupplyCategories.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(SupplyCategory record)
        {
            if (record.SupplyCategoryID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SupplyCategoryID = Guid.NewGuid();
                _db.SupplyCategories.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<SupplyCategory>> ToListAsync()
        {
            return _db.SupplyCategories.OrderBy(x => x.SupplyCategoryName).ToListAsync();
        }
    }
}
