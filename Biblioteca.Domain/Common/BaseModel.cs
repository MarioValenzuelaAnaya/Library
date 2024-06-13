

namespace Biblioteca.Domain.Common
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; } 
        public string? LastModifiedBy { get; set; }

       public DateTime? LastModifiedDate { get; set; }
    }
}
