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
    public class PersonnelTasksController : ApplicationBaseController
    {
        private IPFMOAsync<PersonnelTask> _personnelTask;
        //Initialization
        public PersonnelTasksController()
        {
            var obj = new PersonnelTasksLogic(db);
            _personnelTask = obj;
        }

        // GET: /PersonnelTasks/
        public async Task<ActionResult> Index()
        {
            var personneltasks = db.PersonnelTasks.Include(p => p.Personnel);
            return View(await personneltasks.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            var personneltasks = db.PersonnelTasks.Include(p => p.Personnel);
            return View(await personneltasks.ToListAsync());
        }

        // GET: /PersonnelTasks/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelTask personnelTask = await _personnelTask.FindAsync(id.Value);
            if (personnelTask == null)
            {
                return HttpNotFound();
            }
            return View(personnelTask);
        }

        // GET: /PersonnelTasks/Create
        public ActionResult Create()
        {
            ViewBag.PersonnelID = new SelectList(db.Personnels, "PersonnelID", "PersonnelFullName");
            return View();
        }

        // POST: /PersonnelTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PersonnelTaskID,PersonnelTaskTitle,PersonnelTaskDescription,PersonnelID,PersonnelTaskStartDate,PersonnelTaskEndDate")] PersonnelTask personnelTask)
        {
            if (ModelState.IsValid)
            {
                await _personnelTask.SaveChangesAsync(personnelTask);
                return RedirectToAction("Index");
            }

            ViewBag.PersonnelID = new SelectList(db.Personnels, "PersonnelID", "PersonnelFullName", personnelTask.PersonnelID);
            return View(personnelTask);
        }

        // GET: /PersonnelTasks/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelTask personnelTask = await _personnelTask.FindAsync(id.Value);
            if (personnelTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonnelID = new SelectList(db.Personnels, "PersonnelID", "PersonnelFullName", personnelTask.PersonnelID);
            return View(personnelTask);
        }

        // POST: /PersonnelTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PersonnelTaskID,PersonnelTaskTitle,PersonnelTaskDescription,PersonnelID,PersonnelTaskStartDate,PersonnelTaskEndDate")] PersonnelTask personnelTask)
        {
            if (ModelState.IsValid)
            {
                await _personnelTask.SaveChangesAsync(personnelTask);
                return RedirectToAction("Index");
            }
            ViewBag.PersonnelID = new SelectList(db.Personnels, "PersonnelID", "PersonnelFullName", personnelTask.PersonnelID);
            return View(personnelTask);
        }

        // GET: /PersonnelTasks/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelTask personnelTask = await _personnelTask.FindAsync(id.Value);
            if (personnelTask == null)
            {
                return HttpNotFound();
            }
            return View(personnelTask);
        }

        // POST: /PersonnelTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var personnelTask = await _personnelTask.FindAsync(id);
            await _personnelTask.Remove(personnelTask);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _personnelTask.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
