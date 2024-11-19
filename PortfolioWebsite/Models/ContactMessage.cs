using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}
