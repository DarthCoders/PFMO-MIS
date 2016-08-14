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
    public class PersonnelDesignationsLogic : IPFMOAsync<PersonnelDesignation>
    {
        //Initialization
        private PFMO_DB _db;
        public PersonnelDesignationsLogic(PFMO_DB db)
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

        public Task<PersonnelDesignation> FindAsync(Guid id)
        {
            return _db.PersonnelDesignations.FindAsync(id);
        }

        public Task Remove(PersonnelDesignation record)
        {
            _db.PersonnelDesignations.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(PersonnelDesignation record)
        {
            if (record.PersonnelDesignationID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.PersonnelDesignationID = Guid.NewGuid();
                _db.PersonnelDesignations.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<PersonnelDesignation>> ToListAsync()
        {
            return _db.PersonnelDesignations.OrderBy(x => x.PersonnelDesignationName).ToListAsync();
        }
    }
}
