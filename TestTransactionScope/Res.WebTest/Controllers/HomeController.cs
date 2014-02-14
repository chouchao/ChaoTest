using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Res1.Domain;
using Res.Service;

namespace Res.WebTest.Controllers
{
    public class HomeController : Controller
    {
        public IResDataService ResDataService { get; set; }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var res1data = new Res1Data();
            res1data.Name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //ResDataService.Create(res1data);

            var data = ResDataService.GetAll();
            return View();
        }

    }
}
