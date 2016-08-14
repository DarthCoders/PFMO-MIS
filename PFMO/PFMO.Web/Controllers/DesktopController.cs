using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMO.Web.Controllers
{
    public class DesktopController : ApplicationBaseController
    {
        // GET: Desktop
        public ActionResult Index()
        {
            return View();
        }
    }
}