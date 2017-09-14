using System;
using System.Collections.Generic;

namespace Hackathon.Model.Services
{
	public class ProxyService : Service
	{
		public class ProxyServiceSettings
		{
			public ProxyServiceSettings()
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

				VirtualProxies = new List<VirtualProxyConfig>();
			}

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
			public ServiceLogVerbosities LogVerbositySettings { get; set; }
			public List<VirtualProxyConfig> VirtualProxies { get; set; }
		}

		private ProxyService() { }

		public ProxyService(ServiceCluster cluster, string hostname) : base(cluster, hostname)
		{
			Settings = new ProxyServiceSettings();
		}

		public ProxyService(IService item) : base( item.ServiceCluster, item.HostName )
		{
			if (!(item is ProxyService))
			{
				throw new Exception("Invalid input type.");
			}

			Settings = ((ProxyService) item).Settings ?? new ProxyServiceSettings();
		}

		public ProxyServiceSettings Settings { get; set; }
		public override ServiceTypeEnum ServiceType { get; } = ServiceTypeEnum.Proxy;
	}
}
