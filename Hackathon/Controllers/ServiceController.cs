using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hackathon.Model;
using Hackathon.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				HttpResponseMessage response = client.GetAsync("/service/GetAllByType?serviceType=Engine&serviceType=Proxy&serviceType=Scheduler&serviceType=Engine&serviceType=AppMigration&serviceType=Printing").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserializedObjList = (List<dynamic>)JsonConvert.DeserializeObject(stringData, typeof(List<dynamic>));
				List<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>();
				foreach (var service in myDeserializedObjList)
				{
					serviceViewModels.Add(new ServiceViewModel()
					{
						HostName =service.hostName,
						Id = service.id,
						ServiceCluster = service.serviceCluster.name,
						ServiceType = service.serviceType
					});
				}
				return View(serviceViewModels);
			}
		}

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
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