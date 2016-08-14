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
    public class ProjectsLogic : IPFMOAsync<Project>
    {
        //Initialization
        private PFMO_DB _db;
        public ProjectsLogic(PFMO_DB db)
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

        public Task<Project> FindAsync(Guid id)
        {
            return _db.Projects.FindAsync(id);
        }

        public Task Remove(Project record)
        {
            _db.Projects.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(Project record)
        {
            if (record.ProjectID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.ProjectID = Guid.NewGuid();
                _db.Projects.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<Project>> ToListAsync()
        {
            return _db.Projects.OrderByDescending(x => x.ProjectCompletion).ToListAsync();
        }
    }
}
