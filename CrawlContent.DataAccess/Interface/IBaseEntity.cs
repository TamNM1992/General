using System.ComponentModel.DataAnnotations;

namespace General.DataAccess.Interface
{
    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
        int Deleted { get; set; }

    }
}