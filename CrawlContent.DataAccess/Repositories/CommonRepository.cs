
using General.DataAccess.DBContext;
using General.DataAccess.Interface;

namespace General.DataAccess.Repositories
{
	public class CommonRepository<T> : Repository<CommonDBContext, T>, ICommonRepository<T> where T : class
	{
		public CommonRepository(CommonDBContext context) : base(context)
		{

		}
	}
}
