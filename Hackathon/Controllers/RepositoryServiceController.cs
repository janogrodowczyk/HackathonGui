using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hackathon.Model;
using Hackathon.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    public class RepositoryServiceController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();
		// GET: RepositoryService
		public ActionResult Index()
        {
			return RedirectToAction("Index", "Service");
		}

        // GET: RepositoryService/Details/5
        public ActionResult Details(int id)
        {
			try
			{
				var response = _client.GetAsync("/service/GetRepositoryService" + $"/{id}").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserialized = (RepositoryService)JsonConvert.DeserializeObject(stringData, typeof(RepositoryService));
				return View(myDeserialized);
			}
			catch
			{
				return View();
			}
		}

        // GET: RepositoryService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepositoryService/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
			RepositoryService proxyService = new RepositoryService(new ServiceCluster() { Name = collection["ServiceClusterName"], Id = Guid.Parse(collection["ServiceClusterId"]) }, collection["HostName"]);
	        proxyService.Settings = new RepositoryService.RepositoryServiceSettings()
	        {
		       UseRuleTrace = collection["UseRuleTrace"].Contains("true"),
			   AppImportFolder = collection["AppImportFolder"],

	        };
	        proxyService.HostName = collection["HostName"];
	        proxyService.ModifiedByUserName = collection["ModifiedByUserName"];
	        proxyService.IdentifiedInternally = collection["IdentifiedInternally"].Contains("true");
	        try
	        {
			    await _client.PostAsync("/service/AddRepository", new StringContent(JsonConvert.SerializeObject(proxyService), System.Text.Encoding.UTF8, "application/json"));
			    return RedirectToAction("Index");
	        }
			catch
            {
                return View();
            }
        }

        // GET: RepositoryService/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepositoryService/Edit/5
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

        // GET: RepositoryService/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepositoryService/Delete/5
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