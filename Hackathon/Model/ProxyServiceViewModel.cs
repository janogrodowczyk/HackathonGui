using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
	public class ProxyServiceViewModel : Service
	{
		public string ServiceClusterName { get; set; }
		public Guid ServiceClusterId { get; set; }
		public ServiceLogVerbosities LogVerbositySettings { get; set; } = new ServiceLogVerbosities
			{{ ServiceLogFacilityEnum.AuditActivity, ServiceLogVerbosityEnum.Basic},
				{ ServiceLogFacilityEnum.AuditSecurity, ServiceLogVerbosityEnum.Basic},
				{ ServiceLogFacilityEnum.Service, ServiceLogVerbosityEnum.Info },
				{ ServiceLogFacilityEnum.Audit, ServiceLogVerbosityEnum.Info },
				{ ServiceLogFacilityEnum.Performance, ServiceLogVerbosityEnum.Info },
				{ ServiceLogFacilityEnum.Security, ServiceLogVerbosityEnum.Info },
				{ ServiceLogFacilityEnum.System, ServiceLogVerbosityEnum.Info } };

		public int ListenPort { get; set; }
		public bool AllowHttp { get; set; }
		public int UnencryptedListenPort { get; set; }
		public int AuthenticationListenPort { get; set; }
		public bool KerberosAuthentication { get; set; }
		public string SslBrowserCertificateThumbprint { get; set; }
		public int KeepAliveTimeoutSeconds { get; set; }
		public int MaxHeaderSizeBytes { get; set; }
		public int MaxHeaderLines { get; set; }
		public bool UseWsTrace { get; set; }
		public int PerformanceLoggingInterval { get; set; }
		public int RestListenPort { get; set; }
		public string FormAuthenticationPageTemplate { get; set; }
		public string LoggedOutPageTemplate { get; set; }
		public string ErrorPageTemplate { get; set; }
		public List<VirtualProxyConfig> VirtualProxies { get; set; }
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Proxy;
	}
}
