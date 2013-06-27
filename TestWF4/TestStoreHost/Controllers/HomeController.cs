using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStoreHost.MS.Services;
using TestStoreHost.Models;
using TestStoreHost.MS.Dtos;
using TestStoreHost.MS.Models;
using TestStore;

namespace TestStoreHost.Controllers
{
    public class HomeController : Controller
    {
        public IRequestService RequestService { get; set; }

        public ITaskFlowService TaskFlowService { get; set; }

        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var dto = new RequestQueryDto();
            var datapage = new DataPage(page, pagesize);
            ViewBag.RequestList = RequestService.GetPagedListByDto(dto, datapage, null);
            ViewBag.Datapage = datapage.CreateShowPage();

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Request request)
        {
            request.Status = RequestStatus.New;
            request.UpdateTime = DateTime.Now;
            RequestService.Create(request);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var request = RequestService.GetById(id);
            if (!request.WokflowId.HasValue)
            {
                TaskFlowService.Create(request);
            }
            else
            {
                //TaskFlowService.Create(request);
                if (request.Status == RequestStatus.Pending)
                {
                    TaskFlowService.RunInstance(request, request.Status.ToString());
                }
            }
            return View(request);
        }

        [HttpPost]
        public ActionResult Edit(Request newRequest)
        {
            //request.Status = RequestStatus.New;
            var request = RequestService.GetById(newRequest.Id);
            TryUpdateModel(request);
            request.UpdateTime = DateTime.Now;
            //RequestService.Update(request);
            TaskFlowService.RunInstance(request, "Start");
            return RedirectToAction("Index");
        }

    }
}
