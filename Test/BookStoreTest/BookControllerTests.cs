using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Controllers;
using BookStore.Models;
using Moq;
using Xunit;

namespace BookStoreTest
{
    public class BookControllerTests
    {
        [Fact]
        public void CanPaginate()
        {
            var mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new[]
            {
                new Book {Id = 1, Title = "Book1"},
                new Book {Id = 2, Title = "Book2"},
                new Book {Id = 3, Title = "Book3"},
                new Book {Id = 4, Title = "Book4"},
                new Book {Id = 5, Title = "Book5"},
            });
            var controller = new BookController(mock.Object)
            {
                PageSize = 3
            };
            var result = controller.List(2).ViewData.Model as IEnumerable<Book>;

            //Утверждение
            var bookArray = (result ?? throw new InvalidOperationException()).ToArray();
            Assert.True(bookArray.Length == 2);
            Assert.Equal("Book4", bookArray[0].Title);
            Assert.Equal("Book5", bookArray[1].Title);
        }
    }
}
