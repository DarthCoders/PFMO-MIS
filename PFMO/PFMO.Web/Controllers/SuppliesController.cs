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
    public class SuppliesController : ApplicationBaseController
    {
        private IPFMOAsync<Supply> _supply;
        //Initialization
        public SuppliesController()
        {
            var obj = new SuppliesLogic(db);
            _supply = obj;
        }

        // GET: /Supplies/
        public async Task<ActionResult> Index()
        {
            var supplies = db.Supplies.Include(s => s.Project).Include(s => s.SupplyCategory);
            return View(await supplies.ToListAsync());
        }

        // GET: /Supplies/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = await _supply.FindAsync(id.Value);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: /Supplies/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.SupplyCategoryID = new SelectList(db.SupplyCategories, "SupplyCategoryID", "SupplyCategoryName");
            return View();
        }

        // POST: /Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SupplyID,SupplyCode,SupplyName,SupplyCategoryID,SupplyRemarks,SupplyStatus,SupplyBalance,SupplyUnit,SupplyReorderPoint,Target,ProjectID,EquipmentxpiryDate")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                await _supply.SaveChangesAsync(supply);
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", supply.ProjectID);
            ViewBag.SupplyCategoryID = new SelectList(db.SupplyCategories, "SupplyCategoryID", "SupplyCategoryName", supply.SupplyCategoryID);
            return View(supply);
        }

        // GET: /Supplies/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = await _supply.FindAsync(id.Value);
            if (supply == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", supply.ProjectID);
            ViewBag.SupplyCategoryID = new SelectList(db.SupplyCategories, "SupplyCategoryID", "SupplyCategoryName", supply.SupplyCategoryID);
            return View(supply);
        }

        // POST: /Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SupplyID,SupplyCode,SupplyName,SupplyCategoryID,SupplyRemarks,SupplyStatus,SupplyBalance,SupplyUnit,SupplyReorderPoint,Target,ProjectID,EquipmentxpiryDate")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                await _supply.SaveChangesAsync(supply);
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", supply.ProjectID);
            ViewBag.SupplyCategoryID = new SelectList(db.SupplyCategories, "SupplyCategoryID", "SupplyCategoryName", supply.SupplyCategoryID);
            return View(supply);
        }

        // GET: /Supplies/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = await _supply.FindAsync(id.Value);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: /Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var supply = await _supply.FindAsync(id);
            await _supply.Remove(supply);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _supply.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
