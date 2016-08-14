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
    public class PersonnelsLogic : IPFMOAsync<Personnel>
    {
        //Initialization
        private PFMO_DB _db;
        public PersonnelsLogic(PFMO_DB db)
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

        public Task<Personnel> FindAsync(Guid id)
        {
            return _db.Personnels.FindAsync(id);
        }

        public Task Remove(Personnel record)
        {
            _db.Personnels.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Personnel record)
        {
            if (record.PersonnelID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.PersonnelID = Guid.NewGuid();
                _db.Personnels.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Personnel>> ToListAsync()
        {
            return _db.Personnels.OrderBy(x => x.PersonnelLastName).ToListAsync();
        }
    }
}
