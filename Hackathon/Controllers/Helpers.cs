using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Model;

namespace Hackathon.Controllers
{
    public class Helpers
    {
	    public static List<ServiceViewModel> ToServiceViewModel(List<dynamic> serviceList)
	    {
			List<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>();
		    foreach (var service in serviceList)
		    {
			    serviceViewModels.Add(new ServiceViewModel()
			    {
				    HostName = service.hostName,
				    Id = service.id,
				    ServiceCluster = service.serviceCluster.name,
				    ServiceType = service.serviceType
			    });
		    }
		    return serviceViewModels;
	    }

    }
}
