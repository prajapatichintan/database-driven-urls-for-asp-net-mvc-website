using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DynamicRoutingExample.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index(int Id)
        {
            var objDataAccess = new DataAccess.Repository();
            var Result = objDataAccess.GetCompanyById(Id);
            return View(Result);
        }
	}
}