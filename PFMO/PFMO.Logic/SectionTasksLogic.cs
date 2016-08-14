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
    public class SectionTasksLogic : IPFMOAsync<SectionTask>
    {
        //Initialization
        private PFMO_DB _db;
        public SectionTasksLogic(PFMO_DB db)
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

        public Task<SectionTask> FindAsync(Guid id)
        {
            return _db.SectionTasks.FindAsync(id);
        }

        public Task Remove(SectionTask record)
        {
            _db.SectionTasks.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(SectionTask record)
        {
            if (record.SectionTaskID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.SectionTaskID = Guid.NewGuid();
                _db.SectionTasks.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<SectionTask>> ToListAsync()
        {
            return _db.SectionTasks.OrderBy(x => x.SectionTaskTitle).ToListAsync();
        }
    }
}