using System.ComponentModel.DataAnnotations;

namespace CompanyProvider.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
