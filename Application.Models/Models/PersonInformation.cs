using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Model.Models
{
    [Table("PersonInformations")]
    public class PersonInformation : BaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public bool Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        public byte[]? Image { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string IdNumber { get; set; }
    }
}