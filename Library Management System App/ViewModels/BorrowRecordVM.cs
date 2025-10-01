using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Management_System_App.ViewModels
{
    public class BorrowRecordVM
    {
        public int Id { get; set; }
        [Required]
        public string Borrower { get; set; }

        [Required(ErrorMessage = "Please select a book")]
        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        public DateTime? ReturnDate { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Books { get; set; }
    }
}
