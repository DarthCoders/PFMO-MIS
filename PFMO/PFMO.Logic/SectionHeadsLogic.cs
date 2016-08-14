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
    public class SectionHeadsLogic : IPFMOAsync<SectionHead>
    {
        //Initialization
        private PFMO_DB _db;
        public SectionHeadsLogic(PFMO_DB db)
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

        public Task<SectionHead> FindAsync(Guid id)
        {
            return _db.SectionHeads.FindAsync(id);
        }

        public Task Remove(SectionHead record)
        {
            _db.SectionHeads.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(SectionHead record)
        {
            if (record.SectionHeadID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SectionHeadID = Guid.NewGuid();
                _db.SectionHeads.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<SectionHead>> ToListAsync()
        {
            return _db.SectionHeads.OrderBy(x => x.SectionHeadLastName).ToListAsync();
        }
    }
}
