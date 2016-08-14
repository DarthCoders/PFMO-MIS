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
    public class EquipmentCategoriesController : ApplicationBaseController
    {
        private IPFMOAsync<EquipmentCategory> _equipmentCategory;

        //Initialization
        public EquipmentCategoriesController()
        {
            var obj = new EquipmentCategoriesLogic(db);
            _equipmentCategory = obj;
        }


        // GET: /EquipmentCategories/
        public async Task<ActionResult> Index()
        {
            return View(await _equipmentCategory.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            return View(await _equipmentCategory.ToListAsync());
        }

        // GET: /EquipmentCategories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentCategory equipmentCategory = await _equipmentCategory.FindAsync(id.Value);
            if (equipmentCategory == null)
            {
                return HttpNotFound();
            }
            return View(equipmentCategory);
        }

        // GET: /EquipmentCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EquipmentCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="EquipmentCategoryID,EquipmentCategoryName,EquipmentCategoryDescription")] EquipmentCategory equipmentCategory)
        {
            if (ModelState.IsValid)
            {
                await _equipmentCategory.SaveChangesAsync(equipmentCategory);
                return RedirectToAction("Index");
            }

            return View(equipmentCategory);
        }

        // GET: /EquipmentCategories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentCategory equipmentCategory = await _equipmentCategory.FindAsync(id.Value);
            if (equipmentCategory == null)
            {
                return HttpNotFound();
            }
            return View(equipmentCategory);
        }

        // POST: /EquipmentCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="EquipmentCategoryID,EquipmentCategoryName,EquipmentCategoryDescription")] EquipmentCategory equipmentCategory)
        {
            if (ModelState.IsValid)
            {
                await _equipmentCategory.SaveChangesAsync(equipmentCategory);
                return RedirectToAction("Index");
            }
            return View(equipmentCategory);
        }

        // GET: /EquipmentCategories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentCategory equipmentCategory = await _equipmentCategory.FindAsync(id.Value);
            if (equipmentCategory == null)
            {
                return HttpNotFound();
            }
            return View(equipmentCategory);
        }

        // POST: /EquipmentCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var equipmentCategory = await _equipmentCategory.FindAsync(id);
            await _equipmentCategory.Remove(equipmentCategory);
            return RedirectToAction("Index");
            //await _equipmentCategory.SaveChangesAsync(equipmentCategory);
        }

        protected override void Dispose(bool disposing)
        {
            _equipmentCategory.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
