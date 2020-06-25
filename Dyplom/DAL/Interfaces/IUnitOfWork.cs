using Dyplom.Classes;

namespace Dyplom.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		GenericRepository<Order> Orders { get; }
		GenericRepository<Corporation> Corporations { get; }
		void Save();
	}
}
