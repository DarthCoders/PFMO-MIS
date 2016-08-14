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
    public class SectionsLogic : IPFMOAsync<Section>
    {
        //Initialization
        private PFMO_DB _db;
        public SectionsLogic(PFMO_DB db)
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

        public Task<Section> FindAsync(Guid id)
        {
            return _db.Sections.FindAsync(id);
        }

        public Task Remove(Section record)
        {
            _db.Sections.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Section record)
        {
            if (record.SectionID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SectionID = Guid.NewGuid();
                _db.Sections.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Section>> ToListAsync()
        {
            return _db.Sections.OrderBy(x => x.SectionName).ToListAsync();
        }
    }
}
