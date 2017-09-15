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
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
	public class ServiceController : Controller
	{
		readonly HttpClient _client = new Client.Client().HttpClient();
		// GET: Service
		public async Task<ActionResult> Index()
		{
			List<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>();
			foreach (var type in new [] { "Engine", "Proxy", "Scheduler", "AppMigration", "Printing", "Repository" })
			{
				var response = await _client.GetAsync($"/service/GetAllByType?serviceType={type}");
				string stringData = response.Content.ReadAsStringAsync().Result;
				serviceViewModels.AddRange(Helpers.ToServiceViewModel((List<dynamic>)JsonConvert.DeserializeObject(stringData, typeof(List<dynamic>))));
			}
			return View(serviceViewModels);
		}

		// GET: Service/Details/5
		public async Task<ActionResult> Details(Guid id)
		{
				List<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>();
				foreach (var type in new[] { "Engine", "Proxy", "Scheduler", "AppMigration", "Printing", "Repository" })
				{
					var response = await _client.GetAsync($"/service/GetAllByType?serviceType={type}");
					string stringData = response.Content.ReadAsStringAsync().Result;
					serviceViewModels.AddRange(Helpers.ToServiceViewModel((List<dynamic>)JsonConvert.DeserializeObject(stringData, typeof(List<dynamic>))));
					if (serviceViewModels.Count(i => i.Id==id)>0)
					{
						break;
					}
				}
				var service = serviceViewModels.FirstOrDefault(i =>i.Id==id);
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
		public ActionResult Delete(Guid id)
		{
			HttpResponseMessage response = _client.DeleteAsync("/service/delete" + $"/{id}").Result;
			return RedirectToAction("Index");
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