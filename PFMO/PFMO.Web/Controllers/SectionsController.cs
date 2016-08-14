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
    public class SectionsController : ApplicationBaseController
    {
        private IPFMOAsync<Section> _section;
        //Initialization
        public SectionsController()
        {
            var obj = new SectionsLogic(db);
            _section = obj;
        }

        // GET: /Sections/
        public async Task<ActionResult> Index()
        {
            return View(await _section.ToListAsync());
        }

        public async Task<ActionResult> Table()
        {
            return View(await _section.ToListAsync());
        }

        // GET: /Sections/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await _section.FindAsync(id.Value);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: /Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SectionID,SectionName,SectionType,SectionDescription,SectionDateCreated")] Section section)
        {
            if (ModelState.IsValid)
            {
                await _section.SaveChangesAsync(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        // GET: /Sections/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await _section.FindAsync(id.Value);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SectionID,SectionName,SectionType,SectionDescription,SectionDateCreated")] Section section)
        {
            if (ModelState.IsValid)
            {
                await _section.SaveChangesAsync(section);
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: /Sections/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await _section.FindAsync(id.Value);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var section = await _section.FindAsync(id);
            await _section.Remove(section);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _section.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
