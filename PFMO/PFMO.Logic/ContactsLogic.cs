using PFMO.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMO.Entities;
using PFMO.Contexts;
using System.Data.Entity;

namespace PFMO.Logic
{
    public class ContactsLogic : IPFMO<Contact>
    {

        //Initialization
        private PFMO_DB _db;
        public ContactsLogic(PFMO_DB db)
        {
            _db = db;
        }


        // GetList()
        public List<Contact> GetList()
        {
            return _db.Contacts.OrderBy(x => x.ContactName).ToList();
        }

        // Find()
        public Contact Find(Guid id)
        {
           return _db.Contacts.Find(id);
        }

        //Save()
        public void Save(Contact record)
        {
            if (record.ContactID != Guid.Empty)
            {
                _db.Entry(record).State = EntityState.Modified;
            }
            else
            {
                record.ContactID = Guid.NewGuid();
                _db.Contacts.Add(record);
            }
            _db.SaveChanges();
        }

        //Delete()
        public void Delete(Contact record)
        {
            _db.Contacts.Remove(record);
            _db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}