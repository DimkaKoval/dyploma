using System.Data.Entity;
using Dyplom.Classes;

namespace Dyplom.DAL
{
	/// <inheritdoc />
	/// <summary>
	/// Represents an order.
	/// </summary>
	public class OrderContext : DbContext
	{   /// <summary>
		/// Holds orders.
		/// </summary>
		public DbSet<Order> Orders { get; set; }

		/// <summary>
		/// Contains client personal information.
		/// </summary>
		public DbSet<Corporation> Corporations { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Parameterless OrderContext constructor.
		/// </summary>
		public OrderContext() : base("DBase")
		{

		}
	}
}
