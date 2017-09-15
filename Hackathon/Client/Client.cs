using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hackathon.Model.Services;
using Newtonsoft.Json;

namespace Hackathon.Client
{
    public class Client
    {
	    public HttpClient HttpClient()
	    {
		    HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:5000");
		    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		    return client;
	    }

	}

}
