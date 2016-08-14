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
    public class PersonnelDesignationsController : ApplicationBaseController
    {
        private IPFMOAsync<PersonnelDesignation> _personnelDesignation;
        public PersonnelDesignationsController()
        {
            var obj = new PersonnelDesignationsLogic(db);
            _personnelDesignation = obj;
        }


        // GET: /PersonnelDesignations/
        public async Task<ActionResult> Index()
        {
            return View(await _personnelDesignation.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            return View(await _personnelDesignation.ToListAsync());
        }

        // GET: /PersonnelDesignations/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelDesignation personnelDesignation = await _personnelDesignation.FindAsync(id.Value);
            if (personnelDesignation == null)
            {
                return HttpNotFound();
            }
            return View(personnelDesignation);
        }

        // GET: /PersonnelDesignations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PersonnelDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PersonnelDesignationID,PersonnelDesignationName,PersonnelDesignationDescription")] PersonnelDesignation personnelDesignation)
        {
            if (ModelState.IsValid)
            {
                await _personnelDesignation.SaveChangesAsync(personnelDesignation);
                return RedirectToAction("Index");
            }

            return View(personnelDesignation);
        }

        // GET: /PersonnelDesignations/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelDesignation personnelDesignation = await _personnelDesignation.FindAsync(id.Value);
            if (personnelDesignation == null)
            {
                return HttpNotFound();
            }
            return View(personnelDesignation);
        }

        // POST: /PersonnelDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PersonnelDesignationID,PersonnelDesignationName,PersonnelDesignationDescription")] PersonnelDesignation personnelDesignation)
        {
            if (ModelState.IsValid)
            {
                await _personnelDesignation.SaveChangesAsync(personnelDesignation);
                return RedirectToAction("Index");
            }
            return View(personnelDesignation);
        }

        // GET: /PersonnelDesignations/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelDesignation personnelDesignation = await _personnelDesignation.FindAsync(id.Value);
            if (personnelDesignation == null)
            {
                return HttpNotFound();
            }
            return View(personnelDesignation);
        }

        // POST: /PersonnelDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var personnelDesignation = await _personnelDesignation.FindAsync(id);
            await _personnelDesignation.Remove(personnelDesignation);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _personnelDesignation.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
