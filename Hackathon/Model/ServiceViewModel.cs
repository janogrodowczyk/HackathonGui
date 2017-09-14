using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
    public class ServiceViewModel
    {
	    public ServiceTypeEnum ServiceType { get; set; }
		public Guid Id { get; set; }
		public string HostName { get; set; }
		public string ServiceCluster { get; set; }
	}
}
