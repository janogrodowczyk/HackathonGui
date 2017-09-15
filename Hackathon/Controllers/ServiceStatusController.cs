using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hackathon.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    public class ServiceStatusController : Controller
    {
		public ActionResult Index()
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5000");
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				HttpResponseMessage response = client.GetAsync("/servicestatus/getall").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserializedObjList = (List<ServiceStatus>)JsonConvert.DeserializeObject(stringData, typeof(List<ServiceStatus>));
				return View(myDeserializedObjList);
			}
		}

	    // GET: ServiceStatus/Details/5
	    public ActionResult Details(int id)
	    {
		    using (HttpClient client = new HttpClient())
		    {
			    client.BaseAddress = new Uri("http://localhost:5000");
			    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
			    client.DefaultRequestHeaders.Accept.Add(contentType);
			    HttpResponseMessage response = client.GetAsync("/servicestatus/get" + $"/{id}").Result;
			    string stringData = response.Content.ReadAsStringAsync().Result;
			    var myDeserialized = (ServiceStatus)JsonConvert.DeserializeObject(stringData, typeof(ServiceStatus));
			    return View(myDeserialized);
		    }
	    }
    }
}