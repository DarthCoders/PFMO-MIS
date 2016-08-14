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
    public class EquipmentsLogic : IPFMOAsync<Equipment>
    {
        //Initialization
        private PFMO_DB _db;
        public EquipmentsLogic(PFMO_DB db)
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

        public Task<Equipment> FindAsync(Guid id)
        {
            return _db.Equipments.FindAsync(id);
        }

        public Task Remove(Equipment record)
        {
            _db.Equipments.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Equipment record)
        {
            if (record.EquipmentID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.EquipmentID = Guid.NewGuid();
                _db.Equipments.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Equipment>> ToListAsync()
        {
            return _db.Equipments.OrderBy(x => x.EquipmentCode).ToListAsync();
        }
    }
}
