using System.ComponentModel.DataAnnotations;

namespace Application.Model.ViewModels
{
    public class PersonInformationViewModel
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