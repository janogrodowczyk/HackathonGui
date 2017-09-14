using Hackathon.Model.Services;

namespace Hackathon.Model
{
	public class InnerServerNode : PersistentModel
	{
		protected InnerServerNode() { }
		protected InnerServerNode(InnerServerNode item) : base(item)
		{
			if (item != null)
			{
				HostName = item.HostName;
			}
		}

		internal InnerServerNode(ServerNode item) : base(item)
		{
			if (item != null)
			{
				HostName = item.HostName;
			}
		}

		public string HostName { get; set; }
	}

	public class ServerNode : InnerServerNode
	{
		public ServerNode() { }

	    protected ServerNode(InnerServerNode innerItem) : base(innerItem) {}

		public static ServerNode FromInner(InnerServerNode innerItem)
		{
			return innerItem == null ? null : new ServerNode(innerItem);
		}

		public static InnerServerNode ToInner(ServerNode item)
		{
			return item == null ? null : new InnerServerNode(item);
		}

		// virtual properties, fetched by base properties
		public RepositoryService RepositoryService { get; set; }
		
		public EngineService EngineService { get; set; }
		public ProxyService ProxyService { get; set; }
		public SchedulerService SchedulerService { get; set; }
		public PrintingService PrintingService { get; set; }

	    public bool RepositoryEnabled => RepositoryService != null;
	    public bool EngineEnabled => EngineService != null;
	    public bool ProxyEnabled => ProxyService != null;
	    public bool SchedulerEnabled => SchedulerService != null;
	    public bool PrintingEnabled => PrintingService != null;
	}
}
