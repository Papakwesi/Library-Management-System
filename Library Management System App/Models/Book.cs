using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Author { get; set; }
        [Required] public string ISBN { get; set; }
        [Required] public int Quantity { get; set; }
        public DateTime PublishedDate { get; set; }
    }

}
