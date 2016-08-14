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
    public class PersonnelsController : ApplicationBaseController
    {
        private IPFMOAsync<Personnel> _personnel;
        //Initialization
        public PersonnelsController()
        {
            var obj = new PersonnelsLogic(db);
            _personnel = obj;
        }

        // GET: /Personnels/
        public async Task<ActionResult> Index()
        {
            return View(await _personnel.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            return View(await _personnel.ToListAsync());
        }

        // GET: /Personnels/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await _personnel.FindAsync(id.Value);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // GET: /Personnels/Create
        public ActionResult Create()
        {
            ViewBag.PersonnelDesignationID = new SelectList(db.PersonnelDesignations, "PersonnelDesignationID", "PersonnelDesignationName");
            ViewBag.ProjectTeamID = new SelectList(db.ProjectTeams, "ProjectTeamID", "ProjectTeamName");
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName");
            return View();
        }

        // POST: /Personnels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PersonnelID,PersonnelLastName,PersonnelFirstName,PersonnelGender,PersonnelDesignationID,PersonnelRemarks,SectionID,ProjectTeamID,PersonnelHireDate,PersonnelContactNumber")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                await _personnel.SaveChangesAsync(personnel);
                return RedirectToAction("Index");
            }

            ViewBag.PersonnelDesignationID = new SelectList(db.PersonnelDesignations, "PersonnelDesignationID", "PersonnelDesignationName", personnel.PersonnelDesignationID);
            ViewBag.ProjectTeamID = new SelectList(db.ProjectTeams, "ProjectTeamID", "ProjectTeamName", personnel.ProjectTeamID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", personnel.SectionID);
            return View(personnel);
        }

        // GET: /Personnels/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await _personnel.FindAsync(id.Value);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonnelDesignationID = new SelectList(db.PersonnelDesignations, "PersonnelDesignationID", "PersonnelDesignationName", personnel.PersonnelDesignationID);
            ViewBag.ProjectTeamID = new SelectList(db.ProjectTeams, "ProjectTeamID", "ProjectTeamName", personnel.ProjectTeamID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", personnel.SectionID);
            return View(personnel);
        }

        // POST: /Personnels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PersonnelID,PersonnelLastName,PersonnelFirstName,PersonnelGender,PersonnelDesignationID,PersonnelRemarks,SectionID,ProjectTeamID,PersonnelHireDate,PersonnelContactNumber")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                await _personnel.SaveChangesAsync(personnel);
                return RedirectToAction("Index");
            }
            ViewBag.PersonnelDesignationID = new SelectList(db.PersonnelDesignations, "PersonnelDesignationID", "PersonnelDesignationName", personnel.PersonnelDesignationID);
            ViewBag.ProjectTeamID = new SelectList(db.ProjectTeams, "ProjectTeamID", "ProjectTeamName", personnel.ProjectTeamID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", personnel.SectionID);
            return View(personnel);
        }

        // GET: /Personnels/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await _personnel.FindAsync(id.Value);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // POST: /Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var personnel = await _personnel.FindAsync(id);
            await _personnel.Remove(personnel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _personnel.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
