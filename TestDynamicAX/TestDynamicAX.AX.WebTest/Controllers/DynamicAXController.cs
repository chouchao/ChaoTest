using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDynamicAX.AX.WebTest.Controllers
{
    public class DynamicAXController : Controller
    {
        //
        // GET: /DynamicAX/

        public ActionResult Ver()
        {
            return Content("3");
        }

        public ActionResult List()
        {
            var files = new[]{
                "AXParts/Newtonsoft.Json.dll.part",
                "AXParts/TestDynamicAX.DynamicFileList.dll.part",
                "AXParts/TestDynamicAX.DynamicProcess.dll.part",
            };
            return Content(String.Join(",", files));
        }

    }
}
