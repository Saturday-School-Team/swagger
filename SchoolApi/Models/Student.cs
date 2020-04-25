using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }


        /// <summary>
        /// Student Phone Number
        /// </summary>
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set;}
    }
}