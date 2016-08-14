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
    public class PersonnelTasksLogic : IPFMOAsync<PersonnelTask>
    {
        //Initialization
        private PFMO_DB _db;
        public PersonnelTasksLogic(PFMO_DB db)
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

        public Task<PersonnelTask> FindAsync(Guid id)
        {
            return _db.PersonnelTasks.FindAsync(id);
        }

        public Task Remove(PersonnelTask record)
        {
            _db.PersonnelTasks.Remove(record);
            return _db.SaveChangesAsync();
                 }
        public Task SaveChangesAsync(PersonnelTask record)
        {
            if (record.PersonnelTaskID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.PersonnelTaskID = Guid.NewGuid();
                _db.PersonnelTasks.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<PersonnelTask>> ToListAsync()
        {
            return _db.PersonnelTasks.OrderBy(x => x.PersonnelTaskStartDate).ToListAsync();
        }
    }
}
