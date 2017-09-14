using System.ComponentModel.DataAnnotations;

namespace Hackathon.Model.Services
{
	public interface IService : IPersistentModel
	{
		ServiceCluster ServiceCluster { get; set; }
		string HostName { get; set; }
		ServerNode ServerNode { get; set; }
		ServiceTypeEnum ServiceType { get; }
	}

	public enum ServiceTypeEnum
	{
		Repository,
		Proxy,
		Scheduler,
		Engine,
		AppMigration,
		Printing,
	}

    public abstract class Service : PersistentModel, IService
    {
	    [Required]
		public ServiceCluster ServiceCluster { get; set; }

		[Required]
		public string HostName { get; set; }

		public ServerNode ServerNode { get; set; }

	    [Required]
		public abstract ServiceTypeEnum ServiceType { get; }

		protected Service() { }

	    protected Service(ServiceCluster cluster, string hostName)
	    {
		    ServiceCluster = cluster;
		    HostName = hostName;
	    }
	}
}
