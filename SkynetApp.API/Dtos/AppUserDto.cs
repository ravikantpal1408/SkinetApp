using System.ComponentModel.DataAnnotations;

namespace SkynetApp.API.Dtos
{
    public class AppUserDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string CreadedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
