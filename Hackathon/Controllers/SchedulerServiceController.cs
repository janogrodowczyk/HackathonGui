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
	public class SchedulerServiceController : Controller
	{
		// GET: SchedulerService
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Service");
		}

		// GET: SchedulerService/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:5000");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var response = client.GetAsync("/service/GetSchedulerService" + $"/{id}").Result;
					string stringData = response.Content.ReadAsStringAsync().Result;
					var myDeserialized = (SchedulerService)JsonConvert.DeserializeObject(stringData, typeof(SchedulerService));
					return View(myDeserialized);
				}
			}
			catch
			{
				return View();
			}
		}

		// GET: SchedulerService/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SchedulerService/Create
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

		// GET: SchedulerService/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SchedulerService/Edit/5
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

		// GET: SchedulerService/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SchedulerService/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, IFormCollection collection)
		{
			SchedulerService proxyService = new SchedulerService(new ServiceCluster() { Name = collection["ServiceClusterName"], Id = Guid.Parse(collection["ServiceClusterId"]) }, collection["HostName"]);
			proxyService.Settings = new SchedulerService.SchedulerServiceSettings()
			{ 
				EngineTimeout = Int32.Parse(collection["EngineTimeout"]),
				MaxConcurrentEngines = Int32.Parse(collection["MaxConcurrentEngines"])


			};
			proxyService.HostName = collection["HostName"];
			proxyService.ModifiedByUserName = collection["ModifiedByUserName"];
			proxyService.IdentifiedInternally = collection["IdentifiedInternally"].Contains("true");
			try
			{
				using (HttpClient client = new HttpClient())
				{
					Uri requestUri = new Uri("http://localhost:5000/service/AddRepository");
					var res = await client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(proxyService), System.Text.Encoding.UTF8, "application/json"));
					return RedirectToAction("Index");
				}
			}
			catch
			{
				return View();
			}
		}
	}
}