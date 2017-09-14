using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Hackathon.Model;
using Hackathon.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5000");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.GetAsync("/service/GetAllByType?serviceType=Engine&serviceType=Proxy&serviceType=Scheduler&serviceType=Engine&serviceType=AppMigration&serviceType=Printing").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				List<ServiceViewModel> serviceViewModels =
					Helpers.ToServiceViewModel((List<dynamic>) JsonConvert.DeserializeObject(stringData, typeof(List<dynamic>)));
				return View(serviceViewModels);
			}
		}

        // GET: Service/Details/5
        public ActionResult Details(Guid id)
        {
	        using (HttpClient client = new HttpClient())
	        {
				client.BaseAddress = new Uri("http://localhost:5000");
		        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		        HttpResponseMessage response = client.GetAsync("/service/GetAllByType?serviceType=Engine&serviceType=Proxy&serviceType=Scheduler&serviceType=Engine&serviceType=AppMigration&serviceType=Printing").Result;
		        string stringData = response.Content.ReadAsStringAsync().Result;
		        var service =
			        Helpers.ToServiceViewModel((List<dynamic>)JsonConvert.DeserializeObject(stringData, typeof(List<dynamic>))).FirstOrDefault(i => i.Id==id);
		        switch (service.ServiceType)
		        {

						case ServiceTypeEnum.Engine:
							return RedirectToAction("Details", new RouteValueDictionary(
								new { controller = "EngineService", action = "Details", id = service.Id }));
						case ServiceTypeEnum.Printing:
							return RedirectToAction("Details", new RouteValueDictionary(
								new { controller = "PrintingService", action = "Details", id = service.Id }));
						case ServiceTypeEnum.Proxy:
							return RedirectToAction("Details", new RouteValueDictionary(
								new { controller = "ProxyService", action = "Details", id = service.Id }));
						case ServiceTypeEnum.Repository:
							return RedirectToAction("Details", new RouteValueDictionary(
								new { controller = "RepositoryService", action = "Details", id = service.Id }));
						case ServiceTypeEnum.Scheduler:
						return RedirectToAction("Details", new RouteValueDictionary(
							new { controller = "SchedulerService", action = "Details", id = service.Id }));
				}
			}
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}