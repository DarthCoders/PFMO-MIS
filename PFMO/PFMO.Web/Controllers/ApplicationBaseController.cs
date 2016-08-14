using PFMO.Contexts;
using PFMO.Web.Helpers;
using System.Linq;
using System.Web.Mvc;

namespace PFMO.Web.Controllers
{
    [RequireSSL]
    public class ApplicationBaseController : Controller
    {
        protected PFMO_DB db = new PFMO_DB();
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new Identity_DB();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = string.Concat(new string[] { user.FirstName, " ", user.LastName });
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}