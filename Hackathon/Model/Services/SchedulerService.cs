using System;
using Microsoft.Extensions.Primitives;

namespace Hackathon.Model.Services
{
	public class SchedulerService : Service
	{
		public enum SchedulerServiceTypeEnum
		{
			Master, Slave, MasterAndSlave
		}
		public class SchedulerServiceSettings
		{
			public SchedulerServiceSettings()
			{
				LogVerbositySettings = new ServiceLogVerbosities
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
			}

			public SchedulerServiceTypeEnum SchedulerServiceType { get; set; } = SchedulerServiceTypeEnum.Slave;
			public int MaxConcurrentEngines { get; set; } = 4;
			public int EngineTimeout { get; set; } = 30;
			public ServiceLogVerbosities LogVerbositySettings { get; set; }

		}

		private SchedulerService() { }

		public SchedulerService(ServiceCluster cluster, string hostname) : base(cluster, hostname)
		{
			Settings = new SchedulerServiceSettings();
		}

		public SchedulerService(IService item) : base( item.ServiceCluster, item.HostName )
		{
			if (!(item is SchedulerService))
			{
				throw new Exception("Invalid input type.");
			}

			Settings = ((SchedulerService) item).Settings ?? new SchedulerServiceSettings();
		}

		public SchedulerServiceSettings Settings { get; set; }
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Scheduler;
	}
}
