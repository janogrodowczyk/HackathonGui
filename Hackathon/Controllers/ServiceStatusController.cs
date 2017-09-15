using System.Collections.Generic;
using System.Net.Http;
using Hackathon.Model.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    public class ServiceStatusController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();
		public ActionResult Index()
		{
			HttpResponseMessage response = _client.GetAsync("/servicestatus/getall").Result;
			string stringData = response.Content.ReadAsStringAsync().Result;
			var myDeserializedObjList = (List<ServiceStatus>)JsonConvert.DeserializeObject(stringData, typeof(List<ServiceStatus>));
			return View(myDeserializedObjList);
		}

	    // GET: ServiceStatus/Details/5
	    public ActionResult Details(int id)
	    {
			HttpResponseMessage response = _client.GetAsync("/servicestatus/get" + $"/{id}").Result;
			string stringData = response.Content.ReadAsStringAsync().Result;
			var myDeserialized = (ServiceStatus)JsonConvert.DeserializeObject(stringData, typeof(ServiceStatus));
			return View(myDeserialized);
	    }
    }
}