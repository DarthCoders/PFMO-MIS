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
    public class SectionHeadDesignationsController : ApplicationBaseController
    {
        private IPFMOAsync<SectionHeadDesignation> _sectionHeadDesignation;
        //Initialization
        public SectionHeadDesignationsController()
        {
            var obj = new SectionHeadDesignationsLogic(db);
            _sectionHeadDesignation = obj;
        }

        // GET: /SectionHeadDesignations/
        public async Task<ActionResult> Index()
        {
            return View(await _sectionHeadDesignation.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            return View(await _sectionHeadDesignation.ToListAsync());
        }

        // GET: /SectionHeadDesignations/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHeadDesignation sectionHeadDesignation = await _sectionHeadDesignation.FindAsync(id.Value);
            if (sectionHeadDesignation == null)
            {
                return HttpNotFound();
            }
            return View(sectionHeadDesignation);
        }

        // GET: /SectionHeadDesignations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SectionHeadDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SectionHeadDesignationID,SectionHeadDesignationName,SectionHeadDesignationDescription")] SectionHeadDesignation sectionHeadDesignation)
        {
            if (ModelState.IsValid)
            {
                await _sectionHeadDesignation.SaveChangesAsync(sectionHeadDesignation);
                return RedirectToAction("Index");
            }

            return View(sectionHeadDesignation);
        }

        // GET: /SectionHeadDesignations/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHeadDesignation sectionHeadDesignation = await _sectionHeadDesignation.FindAsync(id.Value);
            if (sectionHeadDesignation == null)
            {
                return HttpNotFound();
            }
            return View(sectionHeadDesignation);
        }

        // POST: /SectionHeadDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SectionHeadDesignationID,SectionHeadDesignationName,SectionHeadDesignationDescription")] SectionHeadDesignation sectionHeadDesignation)
        {
            if (ModelState.IsValid)
            {
                await _sectionHeadDesignation.SaveChangesAsync(sectionHeadDesignation);
                return RedirectToAction("Index");
            }
            return View(sectionHeadDesignation);
        }

        // GET: /SectionHeadDesignations/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionHeadDesignation sectionHeadDesignation = await _sectionHeadDesignation.FindAsync(id.Value);
            if (sectionHeadDesignation == null)
            {
                return HttpNotFound();
            }
            return View(sectionHeadDesignation);
        }

        // POST: /SectionHeadDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var sectionHeadDesignation = await _sectionHeadDesignation.FindAsync(id);
            await _sectionHeadDesignation.Remove(sectionHeadDesignation);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _sectionHeadDesignation.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
