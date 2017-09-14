using System.Collections.Generic;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
    public class ServiceRegistrationRequest
    {
	    public Hackathon.Model.ServiceCluster ServiceCluster { get; set; }
		public string HostName { get; set; }
		public List<ServiceTypeEnum> TypesToRegisterAsDefault { get; set; }
		public List<IService> ServicesToRegister { get; set; }
    }
}
