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
    public class EquipmentCategoriesLogic : IPFMOAsync<EquipmentCategory>
    {
        private PFMO_DB _db;
        public EquipmentCategoriesLogic(PFMO_DB db)
        {
            _db = db;
        }

        public Task<List<EquipmentCategory>> ToListAsync()
        {
            return _db.EquipmentCategories.OrderBy(x => x.EquipmentCategoryName).ToListAsync();
        }

        public Task<EquipmentCategory> FindAsync(Guid id)
        {
            return _db.EquipmentCategories.FindAsync(id);
        }

        public Task SaveChangesAsync(EquipmentCategory record)
        {
            if (record.EquipmentCategoryID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.EquipmentCategoryID = Guid.NewGuid();
                _db.EquipmentCategories.Add(record);
            }
           return _db.SaveChangesAsync();
        }

        public Task Remove(EquipmentCategory record)
        {
            _db.EquipmentCategories.Remove(record);
            return _db.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}