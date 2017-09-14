using System;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
    public class PrintingServiceViewModel : Service
    {
	    public string ServiceClusterName { get; set; }
	    public Guid ServiceClusterId { get; set; }
		public ServiceLogVerbosities LogVerbositySettings = new ServiceLogVerbosities
	    {
		    { ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic },
		    { ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic },
		    { ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
		    { ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
		    { ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
		    { ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
		    { ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info }
	    };
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Printing;
    }
}
