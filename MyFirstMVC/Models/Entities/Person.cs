using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVC.Models.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First name must be 20 characters or less"), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name must be 50 characters or less"), MinLength(2)]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Address must be 100 characters or less"), MinLength(10)]
        public string Address { get; set; }

        [MaxLength(100, ErrorMessage = "Email must be 100 characters or less"), MinLength(6)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}
