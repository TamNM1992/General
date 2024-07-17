using Microsoft.EntityFrameworkCore;
using General.DataAccess.Base;

namespace General.DataAccess.DBContext
{
    public partial class CommonDBContext : PDataContext
    {
        public CommonDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
