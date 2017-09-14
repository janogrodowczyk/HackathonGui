using System;

namespace Hackathon.Model.Services
{
    public class RepositoryService : Service
    {
	    public class RepositoryServiceSettingsCleaningAgent
	    {
		    public int CleaningInternal { get; set; }
		    public int DatabaseCleaningThreshold { get; set; }
		    public int InMemoryCleaningThreshold { get; set; }
	    }

	    public class RepositoryServiceSettingsExternalCert
	    {
		    public string Name;
		    public string ThumbPrint;
	    }

	    public class RepositoryServiceSettings
	    {
		    public RepositoryServiceSettings()
		    {
			    ExternalCertificate = new RepositoryServiceSettingsExternalCert();
				CleaningAgent = new RepositoryServiceSettingsCleaningAgent();
			    LogVerbositySettings = new ServiceLogVerbosities
			    {
				    {ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic },
				    {ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic },
				    {ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.Application, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.License, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.ManagementConsole, ServiceLogVerbosityEnum.Info },
					{ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.Synchronization, ServiceLogVerbosityEnum.Info },
					{ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.UserManagement, ServiceLogVerbosityEnum.Info },
				    {ServiceLogFacilityEnum.RuleAudit, ServiceLogVerbosityEnum.Info }
				};
			}

			public RepositoryServiceSettingsExternalCert ExternalCertificate { get; set; }
		    public RepositoryServiceSettingsCleaningAgent CleaningAgent { get; set; }
		    public ServiceLogVerbosities LogVerbositySettings { get; set; }
		    public string AppImportFolder { get; set; }
		    public bool UseRuleTrace { get; set; }
		}

	    private RepositoryService() { }

		public RepositoryService(ServiceCluster cluster, string hostname) :base(cluster , hostname)
	    {
			Settings = new RepositoryServiceSettings();
	    }

	    public RepositoryService(IService item) : base( item.ServiceCluster, item.HostName )
	    {
		    if (!(item is RepositoryService))
		    {
			    throw new Exception("Invalid input type.");
		    }

		    Settings = ((RepositoryService) item).Settings ?? new RepositoryServiceSettings();
	    }

		public RepositoryServiceSettings Settings { get; set; }
	    public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Repository;
    }
}
