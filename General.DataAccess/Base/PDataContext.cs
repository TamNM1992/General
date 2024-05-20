using Microsoft.EntityFrameworkCore;
using General.DataAccess.Interface;

namespace General.DataAccess.Base
{
	public abstract class PDataContext : DbContext, IDBContext
	{
		protected PDataContext(DbContextOptions options) : base(options)
		{

		}
	}
}
