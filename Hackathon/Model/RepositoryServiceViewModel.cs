using System;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
	public class RepositoryServiceViewModel : Service
	{
		public string ServiceClusterName { get; set; }
		public Guid ServiceClusterId { get; set; }
		public RepositoryService.RepositoryServiceSettingsExternalCert ExternalCertificate { get; set; }
		public RepositoryService.RepositoryServiceSettingsCleaningAgent CleaningAgent { get; set; }
		public ServiceLogVerbosities LogVerbositySettings { get; set; }
		public string AppImportFolder { get; set; }
		public bool UseRuleTrace { get; set; }
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Repository;
		public RepositoryService.RepositoryServiceSettingsExternalCert RepositoryServiceSettingsExternalCert = new RepositoryService.RepositoryServiceSettingsExternalCert();
		public RepositoryService.RepositoryServiceSettingsCleaningAgent RepositoryServiceSettingsCleaningAgent = new RepositoryService.RepositoryServiceSettingsCleaningAgent();
		public ServiceLogVerbosities ServiceLogVerbosities { get; set; } = new ServiceLogVerbosities() {
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
}
