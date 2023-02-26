using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.API.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Column(TypeName = "jsonb")]
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
