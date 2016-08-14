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
    public class SectionTasksController : ApplicationBaseController
    {
        private IPFMOAsync<SectionTask> _sectionTask;
        //Initialization
        public SectionTasksController()
        {
            var obj = new SectionTasksLogic(db);
            _sectionTask = obj;
        }

        // GET: /SectionTasks/
        public async Task<ActionResult> Index()
        {
            var sectiontasks = db.SectionTasks.Include(s => s.Section);
            return View(await sectiontasks.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            var sectiontasks = db.SectionTasks.Include(s => s.Section);
            return View(await sectiontasks.ToListAsync());
        }

        // GET: /SectionTasks/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionTask sectionTask = await _sectionTask.FindAsync(id.Value);
            if (sectionTask == null)
            {
                return HttpNotFound();
            }
            return View(sectionTask);
        }

        // GET: /SectionTasks/Create
        public ActionResult Create()
        {
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName");
            return View();
        }

        // POST: /SectionTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SectionTaskID,SectionTaskTitle,SectionTaskDescription,SectionID,SectionTaskStartDate,SectionTaskEndDate")] SectionTask sectionTask)
        {
            if (ModelState.IsValid)
            {
                await _sectionTask.SaveChangesAsync(sectionTask);
                return RedirectToAction("Index");
            }

            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionTask.SectionID);
            return View(sectionTask);
        }

        // GET: /SectionTasks/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionTask sectionTask = await _sectionTask.FindAsync(id.Value);
            if (sectionTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionTask.SectionID);
            return View(sectionTask);
        }

        // POST: /SectionTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SectionTaskID,SectionTaskTitle,SectionTaskDescription,SectionID,SectionTaskStartDate,SectionTaskEndDate")] SectionTask sectionTask)
        {
            if (ModelState.IsValid)
            {
                await _sectionTask.SaveChangesAsync(sectionTask);
                return RedirectToAction("Index");
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionTask.SectionID);
            return View(sectionTask);
        }

        // GET: /SectionTasks/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionTask sectionTask = await _sectionTask.FindAsync(id.Value);
            if (sectionTask == null)
            {
                return HttpNotFound();
            }
            return View(sectionTask);
        }

        // POST: /SectionTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var sectionTask = await _sectionTask.FindAsync(id);
            await _sectionTask.Remove(sectionTask);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _sectionTask.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
