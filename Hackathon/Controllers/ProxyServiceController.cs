using System;
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
    public class ProxyServiceController : Controller
    {
	    readonly HttpClient _client = new Client.Client().HttpClient();

		// GET: ProxyService
		public ActionResult Index()
        {
			return RedirectToAction("Index", "Service");
		}

        // GET: ProxyService/Details/5
        public ActionResult Details(int id)
        {
			try
			{
				var response = _client.GetAsync("/service/GetProxyService" + $"/{id}").Result;
				string stringData = response.Content.ReadAsStringAsync().Result;
				var myDeserialized = (ProxyService)JsonConvert.DeserializeObject(stringData, typeof(ProxyService));
				return View(myDeserialized);
			}
			catch
			{
				return View();
			}
		}

        // GET: ProxyService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProxyService/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
			ProxyService proxyService = new ProxyService(new ServiceCluster() { Name = collection["ServiceClusterName"], Id = Guid.Parse(collection["ServiceClusterId"]) }, collection["HostName"]);
	        proxyService.Settings = new ProxyService.ProxyServiceSettings()
	        {
				ListenPort = Int32.Parse(collection["ListenPort"]),
				AllowHttp = collection["AllowHttp"].Contains("true"),
				AuthenticationListenPort = Int32.Parse(collection["AuthenticationListenPort"]),
				KerberosAuthentication = collection["KerberosAuthentication"].Contains("true"),
				SslBrowserCertificateThumbprint = collection["SslBrowserCertificateThumbprint"],
				KeepAliveTimeoutSeconds = Int32.Parse(collection["KeepAliveTimeoutSeconds"]),
				MaxHeaderLines = Int32.Parse(collection["MaxHeaderLines"]),
				UseWsTrace = collection["UseWsTrace"].Contains("true"),
				PerformanceLoggingInterval = Int32.Parse(collection["PerformanceLoggingInterval"]),
				RestListenPort = Int32.Parse(collection["RestListenPort"]),
				FormAuthenticationPageTemplate = collection["FormAuthenticationPageTemplate"],
				LoggedOutPageTemplate = collection["LoggedOutPageTemplate"],
				ErrorPageTemplate = collection["ErrorPageTemplate"],
	        };
	        proxyService.HostName = collection["HostName"];
	        proxyService.ModifiedByUserName = collection["ModifiedByUserName"];
	        proxyService.IdentifiedInternally = collection["IdentifiedInternally"].Contains("true");
	        try
	        {
			    await _client.PostAsync("/service/AddProxy", new StringContent(JsonConvert.SerializeObject(proxyService), System.Text.Encoding.UTF8, "application/json"));
			    return RedirectToAction("Index");
	        }
			catch
            {
                return View();
            }
        }

        // GET: ProxyService/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProxyService/Edit/5
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

        // GET: ProxyService/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProxyService/Delete/5
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