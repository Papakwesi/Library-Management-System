using Library_Management_System_App.Models;
using Library_Management_System_App.ViewModels;
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Library_Management_System_App.Controllers
{
    public class BorrowRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BorrowRecord/Index
        public async Task<IActionResult> Index()
        {
            var borrowRecords = await _context.BorrowRecords
                .Include(b => b.Book)
                .ToListAsync();

            return View(borrowRecords);
        }

        // GET: BorrowRecord/Create
        public async Task<IActionResult> Create()
        {
            var vm = new BorrowRecordVM
            {

                Books = _context.Books.Select(b => new SelectListItem { Value = b.Id.ToString(),Text = b.Title})
                    .ToList()
            };

            return View(vm);
        }

        // POST: BorrowRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowRecordVM model)
        {
            if (ModelState.IsValid)
            {
                var borrowRecord = new BorrowRecord
                {
                    Borrower = model.Borrower,
                    BookId = model.BookId,
                    BorrowDate = model.BorrowDate,
                    DueDate = model.DueDate,
                    ReturnDate = model.ReturnDate
                };

                _context.BorrowRecords.Add(borrowRecord);

                var book = await _context.Books.FindAsync(model.BookId);
                if (book != null && book.Quantity > 0)
                {
                    book.Quantity -= 1;
                }

                await _context.SaveChangesAsync();
                TempData["success"] = "Borrow record created successfully!";

                return RedirectToAction(nameof(Index));
            }

            // repopulate dropdowns if validation fails
            model.Books = _context.Books
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Title
                })
                .ToList();

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var record = _context.BorrowRecords.FirstOrDefault(b => b.Id == id);
            if (record == null) return NotFound();

            var vm = new BorrowRecordVM
            {
                Borrower = record.Borrower,
                BookId = record.BookId,
                BorrowDate = record.BorrowDate,
                DueDate = record.DueDate,
                ReturnDate = record.ReturnDate,

                Books = _context.Books
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Title
                    })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BorrowRecordVM model)
        {
            if (!ModelState.IsValid)
            {
                // repopulate dropdown
                model.Books = _context.Books
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Title
                    })
                    .ToList();

                return View(model);
            }

            var record = await _context.BorrowRecords.FindAsync(id);
            if (record == null) return NotFound();

            record.Borrower = model.Borrower;
            record.BookId = model.BookId;
            record.BorrowDate = model.BorrowDate;
            record.DueDate = model.DueDate;
            record.ReturnDate = model.ReturnDate;

            var book = await _context.Books.FindAsync(record.BookId);
            if(book != null)
            {
                book.Quantity += 1;
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Borrow record updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.BorrowRecords.FindAsync(id);
            if (record == null) return NotFound();

            _context.BorrowRecords.Remove(record);
            await _context.SaveChangesAsync();
            TempData["success"] = "Borrow record deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
