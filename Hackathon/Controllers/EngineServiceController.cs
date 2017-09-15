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
    public class EngineServiceController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();

		// GET: EngineService
		public ActionResult Index()
        {
            return RedirectToAction("Index", "Service");
        }

        // GET: EngineService/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
			try
			{
				var response = _client.GetAsync("/service/GetEngineService" + $"/{id}").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserialized = (EngineService)JsonConvert.DeserializeObject(stringData, typeof(EngineService));
				return View(myDeserialized);
			}
			catch
			{
				return View();
			}
		}

        // GET: EngineService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EngineService/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
			EngineService engineService = new EngineService(new ServiceCluster(){Name = collection["ServiceClusterName"], Id = Guid.Parse(collection["ServiceClusterId"])}, collection["HostName"]);
	        engineService.Settings = new EngineService.EngineServiceSettings()
	        {
		        AutosaveInterval = Int32.Parse(collection["AutosaveInterval"]),
		        DocumentTimeout = Int32.Parse(collection["DocumentTimeout"]),
		        TableFilesDirectory = collection["TableFilesDirectory"],
		        DocumentDirectory = collection["DocumentDirectory"],
		        GenericUndoBufferMaxSize = Int32.Parse(collection["GenericUndoBufferMaxSize"]),
		        QvLogEnabled = collection["QvLogEnabled"].Contains("true"),
		        GlobalLogMinuteInterval = Int32.Parse(collection["GlobalLogMinuteInterval"]),
				OverlayDocuments = collection["OverlayDocuments"].Contains("true")
	        };
	        engineService.ModifiedByUserName = collection["ModifiedByUserName"];
			engineService.IdentifiedInternally = collection["IdentifiedInternally"].Contains("true");
            try
            {
				await _client.PostAsync("/service/AddEngine", new StringContent(JsonConvert.SerializeObject(engineService), System.Text.Encoding.UTF8, "application/json"));
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: EngineService/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EngineService/Edit/5
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

        // GET: EngineService/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EngineService/Delete/5
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