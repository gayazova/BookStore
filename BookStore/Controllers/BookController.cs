using System.Linq;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        // на одной странице сведения о 4х товарах
        public int PageSize = 4;
        private IBookRepository repository;

        public BookController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1) => View(new BooksListViewModel
        {
            Books = repository.Books
                .OrderBy(p=>p.Id)
                .Skip((page-1)*PageSize)
                .Take(PageSize),
            PageInfo = new PageInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Books.Count()
            }
        });
    }
}
