using System;

namespace Hackathon.Model.Services
{
    public class PrintingService : Service
    {
	    public class PrintingServiceSettings
	    {
			public PrintingServiceSettings()
		    {
			    LogVerbositySettings = new ServiceLogVerbosities
			    {
					{ ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic },
					{ ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic },
					{ ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
					{ ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
					{ ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
					{ ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
					{ ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info }
			    };
		    }

		    public ServiceLogVerbosities LogVerbositySettings { get; set; }
		}

		private PrintingService() { }

	    public PrintingService(ServiceCluster cluster, string hostname) : base(cluster, hostname)
	    {
		    Settings = new PrintingServiceSettings();
	    }

	    public PrintingService(IService item) : base( item.ServiceCluster, item.HostName )
	    {
		    if (!(item is PrintingService))
		    {
			    throw new Exception("Invalid input type.");
		    }
			Settings = ((PrintingService) item).Settings ?? new PrintingServiceSettings();
	    }

		public PrintingServiceSettings Settings { get; set; }
	    public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Printing;
	}
}
