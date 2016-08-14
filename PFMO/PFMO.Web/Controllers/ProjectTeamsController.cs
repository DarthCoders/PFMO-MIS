using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PFMO.Contexts;
using PFMO.Entities;
using PFMO.Logic.Interface;
using PFMO.Logic;

namespace PFMO.Web.Controllers
{
    [Authorize]
    public class ProjectTeamsController : ApplicationBaseController
    {
        private IPFMOAsync<ProjectTeam> _projectTeam;
        //Initialization
        public ProjectTeamsController()
        {
            var obj = new ProjectTeamsLogic(db);
            _projectTeam = obj;
        }

        // GET: /ProjectTeams/
        public async Task<ActionResult> Index()
        {
            var projectTeams = db.ProjectTeams.Include(p => p.Project);
            return View(await projectTeams.ToListAsync());
        }

        // GET: /ProjectTeams/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = await _projectTeam.FindAsync(id.Value);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }
            return View(projectTeam);
        }

        // GET: /ProjectTeams/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: /ProjectTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ProjectTeamID,ProjectTeamName,ProjectTeamDescription,ProjectID")] ProjectTeam projectTeam)
        {
            if (ModelState.IsValid)
            {
                await _projectTeam.SaveChangesAsync(projectTeam);
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTeam.ProjectID);
            return View(projectTeam);
        }

        // GET: /ProjectTeams/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = await _projectTeam.FindAsync(id.Value);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTeam.ProjectID);
            return View(projectTeam);
        }

        // POST: /ProjectTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ProjectTeamID,ProjectTeamName,ProjectTeamDescription,ProjectID")] ProjectTeam projectTeam)
        {
            if (ModelState.IsValid)
            {
                await _projectTeam.SaveChangesAsync(projectTeam);
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTeam.ProjectID);
            return View(projectTeam);
        }

        // GET: /ProjectTeams/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = await _projectTeam.FindAsync(id.Value);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }
            return View(projectTeam);
        }

        // POST: /ProjectTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var projectTeam = await _projectTeam.FindAsync(id);
            await _projectTeam.Remove(projectTeam);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _projectTeam.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
