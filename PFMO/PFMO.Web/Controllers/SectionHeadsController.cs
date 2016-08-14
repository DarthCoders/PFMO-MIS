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
    public class SectionHeadsController : ApplicationBaseController
    {
        private IPFMOAsync<SectionHead> _sectionHead;
        //Initialization
        public SectionHeadsController()
        {
            var obj = new SectionHeadsLogic(db);
            _sectionHead = obj;
        }

        // GET: /SectionHeads/
        public async Task<ActionResult> Index()
        {
            var sectionheads = db.SectionHeads.Include(s => s.Section).Include(s => s.SectionHeadDesignation);
            return View(await sectionheads.ToListAsync());
        }

        public async Task<ActionResult> Table()
        {
            var sectionheads = db.SectionHeads.Include(s => s.Section).Include(s => s.SectionHeadDesignation);
            return View(await sectionheads.ToListAsync());
        }

        // GET: /SectionHeads/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHead sectionHead = await _sectionHead.FindAsync(id.Value);
            if (sectionHead == null)
            {
                return HttpNotFound();
            }
            return View(sectionHead);
        }

        // GET: /SectionHeads/Create
        public ActionResult Create()
        {
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName");
            ViewBag.SectionHeadDesignationID = new SelectList(db.SectionHeadDesignations, "SectionHeadDesignationID", "SectionHeadDesignationName");
            return View();
        }

        // POST: /SectionHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SectionHeadID,SectionHeadLastName,SectionHeadFirstName,SectionHeadGender,SectionHeadDesignationID,SectionHeadRemarks,SectionID,SectionHeadHireDate,SectionHeadContactNumber")] SectionHead sectionHead)
        {
            if (ModelState.IsValid)
            {
                await _sectionHead.SaveChangesAsync(sectionHead);
                return RedirectToAction("Index");
            }

            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionHead.SectionID);
            ViewBag.SectionHeadDesignationID = new SelectList(db.SectionHeadDesignations, "SectionHeadDesignationID", "SectionHeadDesignationName", sectionHead.SectionHeadDesignationID);
            return View(sectionHead);
        }

        // GET: /SectionHeads/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHead sectionHead = await _sectionHead.FindAsync(id.Value);
            if (sectionHead == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionHead.SectionID);
            ViewBag.SectionHeadDesignationID = new SelectList(db.SectionHeadDesignations, "SectionHeadDesignationID", "SectionHeadDesignationName", sectionHead.SectionHeadDesignationID);
            return View(sectionHead);
        }

        // POST: /SectionHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SectionHeadID,SectionHeadLastName,SectionHeadFirstName,SectionHeadGender,SectionHeadDesignationID,SectionHeadRemarks,SectionID,SectionHeadHireDate,SectionHeadContactNumber")] SectionHead sectionHead)
        {
            if (ModelState.IsValid)
            {
                await _sectionHead.SaveChangesAsync(sectionHead);
                return RedirectToAction("Index");
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", sectionHead.SectionID);
            ViewBag.SectionHeadDesignationID = new SelectList(db.SectionHeadDesignations, "SectionHeadDesignationID", "SectionHeadDesignationName", sectionHead.SectionHeadDesignationID);
            return View(sectionHead);
        }

        // GET: /SectionHeads/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHead sectionHead = await _sectionHead.FindAsync(id.Value);
            if (sectionHead == null)
            {
                return HttpNotFound();
            }
            return View(sectionHead);
        }

        // POST: /SectionHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var sectionHead = await _sectionHead.FindAsync(id);
            await _sectionHead.Remove(sectionHead);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _sectionHead.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
