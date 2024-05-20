
using General.DataAccess.DBContext;
using General.DataAccess.Interface;

namespace General.DataAccess.UnitOfWork
{
	public class CommonUoW : UnitOfWork<CommonDBContext>, ICommonUoW
	{


		public CommonUoW(CommonDBContext context) : base(context)
		{
		}

	}
}
