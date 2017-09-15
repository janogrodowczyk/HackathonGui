using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hackathon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    public class ServiceClusterController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();
		// GET: ServiceCluster
		public ActionResult Index()
        {
	        var myDeserializedObjList = new List<ServiceCluster>();

			try
	        {
			    HttpResponseMessage response = _client.GetAsync("/servicecluster/getall").Result;
			    string stringData = response.Content.ReadAsStringAsync().Result;
			    myDeserializedObjList =
				    (List<ServiceCluster>) JsonConvert.DeserializeObject(stringData, typeof(List<ServiceCluster>));
			}
	        catch (Exception)
	        {
		        // ignored
	        }
	        return View(myDeserializedObjList);
		}

        // GET: ServiceCluster/Details/5
        public ActionResult Details(string id)
        {
				HttpResponseMessage response = _client.GetAsync("/servicecluster/get" + $"/{id}").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserialized = (ServiceCluster)JsonConvert.DeserializeObject(stringData, typeof(ServiceCluster));
				return View(myDeserialized);
		}

        // GET: ServiceCluster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceCluster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiceCluster serviceCluster)
        {
            try
            {
		        serviceCluster.Id = Guid.NewGuid();
		        serviceCluster.SharedFolderSettings.RootFolder = "C://whichever";
		        HttpResponseMessage respon = await _client.PostAsync("ServiceCluster/add", new StringContent(JsonConvert.SerializeObject(serviceCluster), System.Text.Encoding.UTF8, "application/json"));
				return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: ServiceCluster/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceCluster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ServiceCluster serviceCluster)
        {
            try
            {
				HttpResponseMessage response = _client.PutAsync("/servicecluster/Update" + $"/{id}", new StringContent(JsonConvert.SerializeObject(serviceCluster), System.Text.Encoding.UTF8, "application/json")).Result;
		        string stringData = response.Content.ReadAsStringAsync().Result;
		        var myDeserialized = (ServiceCluster)JsonConvert.DeserializeObject(stringData, typeof(ServiceCluster));
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceCluster/Delete/5
        public ActionResult Delete(string id)
        {
		    HttpResponseMessage response = _client.DeleteAsync("/servicecluster/delete" + $"/{id}").Result;
			string stringData = response.Content.ReadAsStringAsync().Result;
		    var myDeserialized = (ServiceCluster)JsonConvert.DeserializeObject(stringData, typeof(ServiceCluster));
		    return RedirectToAction("Index");
        }

        // POST: ServiceCluster/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
		        HttpResponseMessage response = _client.DeleteAsync("/servicecluster/delete" + $"/{id}").Result;
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}