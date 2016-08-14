using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PFMO.Entities;
using PFMO.Logic.Interface;
using PFMO.Logic;

namespace PFMO.Web.Controllers
{
    [Authorize]
    public class PinboardsController : ApplicationBaseController
    {
        private IPFMOAsync<Pinboard> _pinboard;
        //Initialization
        public PinboardsController()
        {
            var obj = new PinboardsLogic(db);
            _pinboard = obj;
        }

        // GET: /Pinboards/
        public async Task<ActionResult> Index()
        {
            return View(await _pinboard.ToListAsync());
        }

        // GET: /Pinboards/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pinboard pinboard = await _pinboard.FindAsync(id.Value);
            if (pinboard == null)
            {
                return HttpNotFound();
            }
            return View(pinboard);
        }

        // GET: /Pinboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pinboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PinboardID,PinboardName,PinboardContent,PinboardDate")] Pinboard pinboard)
        {
            if (ModelState.IsValid)
            {
                await _pinboard.SaveChangesAsync(pinboard);
                return RedirectToAction("Index");
            }

            return View(pinboard);
        }

        // GET: /Pinboards/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pinboard pinboard = await _pinboard.FindAsync(id.Value);
            if (pinboard == null)
            {
                return HttpNotFound();
            }
            return View(pinboard);
        }

        // POST: /Pinboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PinboardID,PinboardName,PinboardContent,PinboardDate")] Pinboard pinboard)
        {
            if (ModelState.IsValid)
            {
                await _pinboard.SaveChangesAsync(pinboard);
                return RedirectToAction("Index");
            }
            return View(pinboard);
        }

        // GET: /Pinboards/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pinboard pinboard = await _pinboard.FindAsync(id.Value);
            if (pinboard == null)
            {
                return HttpNotFound();
            }
            return View(pinboard);
        }

        // POST: /Pinboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var pinboard = await _pinboard.FindAsync(id);
            await _pinboard.Remove(pinboard);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _pinboard.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
