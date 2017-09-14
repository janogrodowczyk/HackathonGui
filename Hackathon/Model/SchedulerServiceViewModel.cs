using System;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
	public class SchedulerServiceViewModel : Service
	{
		public string ServiceClusterName { get; set; }
		public Guid ServiceClusterId { get; set; }
		public ServiceLogVerbosities LogVerbosities = new ServiceLogVerbosities
		{
			{ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic },
			{ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic },
			{ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.Application, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info },
			{ServiceLogFacilityEnum.TaskExecution, ServiceLogVerbosityEnum.Info}
		};
		public SchedulerService.SchedulerServiceTypeEnum SchedulerServiceType { get; set; } = SchedulerService.SchedulerServiceTypeEnum.Slave;
		public int MaxConcurrentEngines { get; set; } = 4;
		public int EngineTimeout { get; set; } = 30;
		public ServiceLogVerbosities LogVerbositySettings { get; set; }
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Scheduler;
	}
}
