using System.ComponentModel.DataAnnotations;

namespace WebAppTutorial.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 20 characters. ")]
        public string Name { get; set; }
        [RegularExpression(@"[a-z0-9]+@[a-z]+\.[a-z]{2,3}")]
        public string Email { set; get; }
        
        [Required]
        public Dep Department { set; get; }


        public string? photoPath { set; get; }
    }
    public enum Dep
    {
        HR = 1,
        Financial = 2,
        Selling = 3
    }
}
