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
    public class EquipmentsController : ApplicationBaseController
    {
        private IPFMOAsync<Equipment> _equipment;

        //Initialization
        public EquipmentsController()
        {
            var obj = new EquipmentsLogic(db);
            _equipment = obj;
        }

        // GET: /Equipments/
        public async Task<ActionResult> Index()
        {
            return View(await _equipment.ToListAsync());
        }

        // GET: /Equipments/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await _equipment.FindAsync(id.Value);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: /Equipments/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentCategoryID = new SelectList(db.EquipmentCategories, "EquipmentCategoryID", "EquipmentCategoryName");
            //ViewBag.EquipmentCategoryID = new SelectList(_equipmentCategory.EquipmentCategories, "EquipmentCategoryID", "EquipmentCategoryName");
            return View();
        }

        // POST: /Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="EquipmentID,EquipmentCode,EquipmentName,EquipmentCategoryID,EquipmentRemarks,EquipmentStatus,EquipmentBalance,EquipmentUnit,EquipmentReorderPoint,Target,EquipmentxpiryDate")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                await _equipment.SaveChangesAsync(equipment);
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentCategoryID = new SelectList(db.EquipmentCategories, "EquipmentCategoryID", "EquipmentCategoryName", equipment.EquipmentCategoryID);
            return View(equipment);
        }

        // GET: /Equipments/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await _equipment.FindAsync(id.Value);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentCategoryID = new SelectList(db.EquipmentCategories, "EquipmentCategoryID", "EquipmentCategoryName", equipment.EquipmentCategoryID);
            return View(equipment);
        }

        // POST: /Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="EquipmentID,EquipmentCode,EquipmentName,EquipmentCategoryID,EquipmentRemarks,EquipmentStatus,EquipmentBalance,EquipmentUnit,EquipmentReorderPoint,Target,EquipmentxpiryDate")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                await _equipment.SaveChangesAsync(equipment);
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentCategoryID = new SelectList(db.EquipmentCategories, "EquipmentCategoryID", "EquipmentCategoryName", equipment.EquipmentCategoryID);
            return View(equipment);
        }

        // GET: /Equipments/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await _equipment.FindAsync(id.Value);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: /Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var equipment = await _equipment.FindAsync(id);
            await _equipment.Remove(equipment);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _equipment.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
