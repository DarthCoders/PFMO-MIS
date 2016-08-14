using System;
using System.Net;
using System.Web.Mvc;
using PFMO.Entities;
using PFMO.Logic.Interface;
using PFMO.Logic;

namespace PFMO.Web.Controllers
{
    [Authorize]
    public class ContactsController : ApplicationBaseController
    {
        private IPFMO<Contact> _contacts;

        //Initialization
        public ContactsController()
        {
            var obj = new ContactsLogic(db);
            _contacts = obj;
        }

        // GET: /Contacts/
        public ActionResult Index()
        {
            return View(_contacts.GetList());
        }
        public ActionResult Table()
        {
            return View(_contacts.GetList());
        }


        // GET: /Contacts/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = _contacts.Find(id.Value);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}


        // GET: /Contacts/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: /Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ContactID,ContactName,ContactDescription,ContactType,ContactOffice,ContactEmail,ContactNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contacts.Save(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //// GET: /Contacts/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = _contacts.Find(id.Value);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: /Contacts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ContactID,ContactName,ContactDescription,ContactType,ContactOffice,ContactEmail,ContactNumber")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _contacts.Save(contact);
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}

        // GET: /Contacts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contacts.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var contact = _contacts.Find(id);
            _contacts.Delete(contact);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _contacts.Dispose(disposing);
            base.Dispose(disposing);
        }

    }
}