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
    public class PrintingServiceController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();

		// GET: PrintingService
		public ActionResult Index()
        {
			return RedirectToAction("Index", "Service");
		}

        // GET: PrintingService/Details/5
        public ActionResult Details(Guid id)
        {
	        try
	        {
			    var response = _client.GetAsync("/service/GetPrintingService" + $"/{id}").Result;
			    string stringData = response.Content.ReadAsStringAsync().Result;
			    var myDeserialized = (PrintingService)JsonConvert.DeserializeObject(stringData, typeof(PrintingService));
			    return View(myDeserialized);
	        }
	        catch
	        {
		        return View();
	        }
        }

        // GET: PrintingService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrintingService/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
			PrintingService printingService = new PrintingService(new ServiceCluster() { Name = collection["ServiceClusterName"], Id = Guid.Parse(collection["ServiceClusterId"]) }, collection["HostName"]);
	        printingService.ModifiedByUserName = collection["ModifiedByUserName"];
	        printingService.IdentifiedInternally = collection["IdentifiedInternally"].Contains("true");
	        printingService.HostName = collection["HostName"];
			try
            {
				await _client.PostAsync("/service/AddPrinting", new StringContent(JsonConvert.SerializeObject(printingService), System.Text.Encoding.UTF8, "application/json"));
		        return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

        // GET: PrintingService/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrintingService/Edit/5
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

        // GET: PrintingService/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrintingService/Delete/5
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