using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Books);
    }
}
