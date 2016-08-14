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
    public class SectionHeadDesignationsLogic : IPFMOAsync<SectionHeadDesignation>
    {
        //Initialization
        private PFMO_DB _db;
        public SectionHeadDesignationsLogic(PFMO_DB db)
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

        public Task<SectionHeadDesignation> FindAsync(Guid id)
        {
            return _db.SectionHeadDesignations.FindAsync(id);
        }

        public Task Remove(SectionHeadDesignation record)
        {
            _db.SectionHeadDesignations.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(SectionHeadDesignation record)
        {
            if (record.SectionHeadDesignationID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SectionHeadDesignationID = Guid.NewGuid();
                _db.SectionHeadDesignations.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<SectionHeadDesignation>> ToListAsync()
        {
            return _db.SectionHeadDesignations.OrderBy(x => x.SectionHeadDesignationName).ToListAsync();
        }
    }
}
