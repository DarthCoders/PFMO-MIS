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
    public class SupplyCategoriesController : ApplicationBaseController
    {
        private IPFMOAsync<SupplyCategory> _supplyCategory;
        //Initialization
        public SupplyCategoriesController()
        {
            var obj = new SupplyCategoriesLogic(db);
            _supplyCategory = obj;
        }

        // GET: /SupplyCategories/
        public async Task<ActionResult> Index()
        {
            return View(await _supplyCategory.ToListAsync());
        }
        public async Task<ActionResult> Table()
        {
            return View(await _supplyCategory.ToListAsync());
        }

        // GET: /SupplyCategories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyCategory supplyCategory = await _supplyCategory.FindAsync(id.Value);
            if (supplyCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplyCategory);
        }

        // GET: /SupplyCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SupplyCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="SupplyCategoryID,SupplyCategoryName,SupplyCategoryDescription")] SupplyCategory supplyCategory)
        {
            if (ModelState.IsValid)
            {
                await _supplyCategory.SaveChangesAsync(supplyCategory);
                return RedirectToAction("Index");
            }

            return View(supplyCategory);
        }

        // GET: /SupplyCategories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyCategory supplyCategory = await _supplyCategory.FindAsync(id.Value);
            if (supplyCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplyCategory);
        }

        // POST: /SupplyCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SupplyCategoryID,SupplyCategoryName,SupplyCategoryDescription")] SupplyCategory supplyCategory)
        {
            if (ModelState.IsValid)
            {
                await _supplyCategory.SaveChangesAsync(supplyCategory);
                return RedirectToAction("Index");
            }
            return View(supplyCategory);
        }

        // GET: /SupplyCategories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyCategory supplyCategory = await _supplyCategory.FindAsync(id.Value);
            if (supplyCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplyCategory);
        }

        // POST: /SupplyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var supplyCategory = await _supplyCategory.FindAsync(id);
            await _supplyCategory.Remove(supplyCategory);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _supplyCategory.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
