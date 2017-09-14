using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Hackathon.Model
{
	public interface IPersistentModel
	{
		Guid Id { get; set; }
		DateTime CreatedDate { get; set; }
		DateTime ModifiedDate { get; set; }
		void Identify();
	}

	[DebuggerDisplay("[{GetType()}] ID={Id}")]
	public class PersistentModel : IPersistentModel
	{
		protected PersistentModel()
		{
			IdentifiedInternally = false;
		}

		protected PersistentModel(PersistentModel item)
		{
			IdentifiedInternally = false;
			if (item != null)
			{
				Id = item.Id;
				CreatedDate = item.CreatedDate;
				ModifiedDate = item.ModifiedDate;
				ModifiedByUserName = item.ModifiedByUserName;
			}
		}

		public Guid Id { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }

		public string ModifiedByUserName { get; set; }

		[NotMapped]
		public bool IdentifiedInternally { get; set; }

		public virtual void Identify()
		{
			if (Id == default(Guid)) Id = Guid.NewGuid();
			IdentifiedInternally = true;
		}

		public virtual void Init(bool initOptional) { }

		public virtual void ModifyUserName(string modifiedByUserName)
		{
			ModifiedByUserName = modifiedByUserName;
		}

		public virtual void PreUpdate()
		{
			Identify();
			if (CreatedDate == DateTime.MinValue)
			{
				CreatedDate = DateTime.UtcNow;
			}
			else
			{
				ModifiedDate = DateTime.UtcNow;
			}
		}

		public override bool Equals(object obj)
		{
			PersistentModel x = obj as PersistentModel;
			return (x != null && base.Equals(x)
			        && Id.Equals(x.Id)
			        && IdentifiedInternally.Equals(x.IdentifiedInternally)
			        && CreatedDate.Equals(x.CreatedDate)
			        && ModifiedDate.Equals(x.ModifiedDate)
			        && (ModifiedByUserName?.Equals(x.ModifiedByUserName) ?? x.ModifiedByUserName == null));
		}

		public override int GetHashCode()
		{
			return base.GetHashCode()
			       ^ (Id.GetHashCode() * 397)
			       ^ (IdentifiedInternally.GetHashCode() * 397)
			       ^ (CreatedDate.GetHashCode() * 397)
			       ^ (ModifiedDate.GetHashCode() * 397)
			       ^ ((ModifiedByUserName != null ? ModifiedByUserName.GetHashCode() : 0) * 397);
		}
	}
}
