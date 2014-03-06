using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product.Service;

namespace WebTest.Controllers
{
    public class TestController : Controller
    {
        public ITestDataManager TestDataManager { get; set; }

        public ActionResult Index()
        {
            TestDataManager.InitData();
            return Content("");
            //return View();
        }
    }
}
