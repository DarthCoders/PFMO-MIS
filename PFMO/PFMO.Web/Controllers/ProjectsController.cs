using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PFMO.Entities;
using PFMO.Logic.Interface;
using PFMO.Logic;

namespace PFMO.Web.Controllers
{
    [Authorize]
    public class ProjectsController : ApplicationBaseController
    {
        private IPFMOAsync<Project> _project;
        //Initialization
        public ProjectsController()
        {
            var obj = new ProjectsLogic(db);
            _project = obj;
        }

        // GET: /Projects/
        public async Task<ActionResult> Index()
        {
            return View(await _project.ToListAsync());
        }

        // GET: /Projects/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await _project.FindAsync(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: /Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ProjectID,ProjectName,ProjectStatus,ProjectCompletion,ProjectStartDate,ProjectEndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                await _project.SaveChangesAsync(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: /Projects/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await _project.FindAsync(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ProjectID,ProjectName,ProjectStatus,ProjectCompletion,ProjectStartDate,ProjectEndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                await _project.SaveChangesAsync(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: /Projects/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await _project.FindAsync(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Project project = await _project.FindAsync(id);
            await _project.Remove(project);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _project.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
