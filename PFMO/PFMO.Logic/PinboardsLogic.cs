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
    public class PinboardsLogic : IPFMOAsync<Pinboard>
    {
        //Initialization
        private PFMO_DB _db;
        public PinboardsLogic(PFMO_DB db)
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

        public Task<Pinboard> FindAsync(Guid id)
        {
            return _db.Pinboards.FindAsync(id);
        }

        public Task Remove(Pinboard record)
        {
            _db.Pinboards.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Pinboard record)
        {
            if (record.PinboardID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.PinboardID = Guid.NewGuid();
                _db.Pinboards.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Pinboard>> ToListAsync()
        {
            return _db.Pinboards.OrderBy(x => x.PinboardDate).ToListAsync();
        }
    }
}
