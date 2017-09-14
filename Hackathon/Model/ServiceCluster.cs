using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Hackathon.Model.Services;

namespace Hackathon.Model
{
	public class SharedFolderSettings
	{
		public string RootFolder { get; set; }
		public string AppFolder { get; set; }
		public string StaticContentRootFolder { get; set; }
		public string ArchivedLogsRootFolder { get; set; }

		public void PreUpdate()
		{
			if (string.IsNullOrEmpty(RootFolder))
			{
				throw new ArgumentException("Invalid RootFolder");
			}

			if (string.IsNullOrEmpty(AppFolder))
			{
				AppFolder = Path.Combine(RootFolder, "Apps");
			}

			if (string.IsNullOrEmpty(StaticContentRootFolder))
			{
				StaticContentRootFolder = Path.Combine(RootFolder, "StaticContent");
			}

			if (string.IsNullOrEmpty(ArchivedLogsRootFolder))
			{
				ArchivedLogsRootFolder = Path.Combine(RootFolder, "ArchivedLogs");
			}
		}
	}

	public class DatabaseConnectionSetting
	{
		public string HostName { get; set; }
		public int Port { get; set; }
		public int SSLPort { get; set; }

		public string User { get; set; }
		public string Password { get; set; }
		public string DatabaseName { get; set; }
	}

	public class ServiceDatabaseConnectionSettings : Dictionary<ServiceTypeEnum, DatabaseConnectionSetting> {}

	public class ServiceCluster: Hackathon.Model.PersistentModel
    {
		[Required]
		public string Name { get; set; }
		public SharedFolderSettings SharedFolderSettings { get; set; }
		public ServiceDatabaseConnectionSettings DatabaseConnectionSettings { get; set; }

	    public ServiceCluster()
	    {
		    SharedFolderSettings = new SharedFolderSettings();
		    DatabaseConnectionSettings = new ServiceDatabaseConnectionSettings();
	    }

	    public override void PreUpdate()
	    {
		    SharedFolderSettings.PreUpdate();
		    base.PreUpdate();
		}
    }
}
