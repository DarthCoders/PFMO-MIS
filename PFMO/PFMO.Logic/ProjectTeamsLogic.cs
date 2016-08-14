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
    public class ProjectTeamsLogic : IPFMOAsync<ProjectTeam>
    {
        //Initialization
        private PFMO_DB _db;
        public ProjectTeamsLogic(PFMO_DB db)
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

        public Task<ProjectTeam> FindAsync(Guid id)
        {
            return _db.ProjectTeams.FindAsync(id);
        }

        public Task Remove(ProjectTeam record)
        {
            _db.ProjectTeams.Remove(record);
            return _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync(ProjectTeam record)
        {
            if (record.ProjectTeamID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.ProjectTeamID = Guid.NewGuid();
                _db.ProjectTeams.Add(record);
            }
            return _db.SaveChangesAsync();
        }

        public Task<List<ProjectTeam>> ToListAsync()
        {
            return _db.ProjectTeams.OrderBy(x => x.ProjectTeamName).ToListAsync();
        }
    }
}
