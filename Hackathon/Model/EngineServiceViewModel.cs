using System;
using System.Collections.Generic;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
    public class EngineServiceViewModel : Service
    {
		public string ServiceClusterName { get; set; }
		public Guid ServiceClusterId { get; set; }
	    public override ServiceTypeEnum ServiceType { get; }
	    public List<int> ListenerPorts { get; set; } = new List<int> { 4747 };
	    public bool OverlayDocuments { get; set; } = true;
	    public int AutosaveInterval { get; set; } = 30;
	    public int DocumentTimeout { get; set; } = 28800;
	    public string TableFilesDirectory { get; set; } = string.Empty;
	    public string DocumentDirectory { get; set; } = @"C:\ProgramData\Qlik\Sense\Apps\";
	    public int GenericUndoBufferMaxSize { get; set; } = 100;
	    public bool QvLogEnabled { get; set; } = true;
	    public int GlobalLogMinuteInterval { get; set; } = 5;

	    public ServiceLogVerbosities LogVerbositySettings { get; set; } = new ServiceLogVerbosities
	    {
		    {ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic },
		    {ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic },
		    {ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
		    {ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
		    {ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
		    {ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
		    {ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info }
	    };
	}
}
