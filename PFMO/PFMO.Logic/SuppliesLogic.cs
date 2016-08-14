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
    public class SuppliesLogic : IPFMOAsync<Supply>
    {
        //Initialization
        private PFMO_DB _db;
        public SuppliesLogic(PFMO_DB db)
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

        public Task<Supply> FindAsync(Guid id)
        {
            return _db.Supplies.FindAsync(id);
        }

        public Task Remove(Supply record)
        {
            _db.Supplies.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Supply record)
        {
            if (record.SupplyID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SupplyID = Guid.NewGuid();
                _db.Supplies.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Supply>> ToListAsync()
        {
            return _db.Supplies.OrderBy(x => x.SupplyCode).ToListAsync();
        }
    }
}
