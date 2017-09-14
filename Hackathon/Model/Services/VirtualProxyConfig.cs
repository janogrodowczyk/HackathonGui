using System.Collections.Generic;

namespace Hackathon.Model.Services
{
	public class VirtualProxyConfig : PersistentModel
	{
		public enum AuthenticationMethodEnum
		{
			Ticket, HeaderStaticUserDirectory, HeaderDynamicUserDirectory, SAML, JWT
		}

		public enum HeaderAuthenticationModeEnum
		{
			NotAllowed, StaticUserDirectory, DynamicUserDirectory, Undefined
		}

		public enum AnonymousAccessModeEnum
		{
			NoAnonymousUser, AllowAnonymous, AlwaysAnonymous
		}

		public string Prefix { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string AuthenticationModuleRedirectUri { get; set; } = string.Empty;
		public string SessionModuleBaseUri { get; set; } = string.Empty;
		public string LoadBalancingModuleBaseUri { get; set; } = string.Empty;
		public List<string> LoadBalancingServerNodeHostNames { get; set; } = new List<string>();
		public AuthenticationMethodEnum AuthenticationMethod { get; set; } = AuthenticationMethodEnum.Ticket;
		public HeaderAuthenticationModeEnum HeaderAuthenticationMode { get; set; } = HeaderAuthenticationModeEnum.NotAllowed;
		public string HeaderAuthenticationStaticUserDirectory { get; set; } = string.Empty;
		public string HeaderAuthenticationDynamicUserDirectory { get; set; } = string.Empty;
		public AnonymousAccessModeEnum AnonymousAccessMode { get; set; } = AnonymousAccessModeEnum.NoAnonymousUser;
		public string WindowsAuthenticationEnabledDevicePattern { get; set; } = string.Empty;
		public string SessionCookieHeaderName { get; set; } = string.Empty;
		public string SessionCookieDomain { get; set; } = string.Empty;
		public string AdditionalResponseHeaders { get; set; } = string.Empty;
		public int SessionInactivityTimeout { get; set; } = 30;
		public bool ExtendedSecurityEnvironment { get; set; }
		public List<string> WebsocketCrossOriginWhiteList { get; set; } = new List<string>();
		public bool DefaultVirtualProxy { get; set; }

		public List<ServerNode> LoadBalancingServerNodes = new List<ServerNode>();

	}
}
