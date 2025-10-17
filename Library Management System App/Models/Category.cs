using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
    }
}
