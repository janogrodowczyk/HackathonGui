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
		        using (HttpClient client = new HttpClient())
		        {
			        client.BaseAddress = new Uri("http://localhost:5000");
			        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			        var response = client.GetAsync("/service/GetPrintingService" + $"/{id}").Result;
			        string stringData = response.Content.ReadAsStringAsync().Result;
			        var myDeserialized = (PrintingService)JsonConvert.DeserializeObject(stringData, typeof(PrintingService));
			        return View(myDeserialized);
		        }
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
	            using (HttpClient client = new HttpClient())
	            {
		            Uri requestUri = new Uri("http://localhost:5000/service/AddPrinting");
					var hej = JsonConvert.SerializeObject(printingService);

					var res = await client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(printingService), System.Text.Encoding.UTF8, "application/json"));
		            return RedirectToAction("Index");
	            }
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