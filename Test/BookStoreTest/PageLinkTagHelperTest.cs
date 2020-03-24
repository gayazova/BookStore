using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Controllers;
using BookStore.Infrastructure;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using Xunit;

namespace BookStoreTest
{
    public class PageLinkTagHelperTest
    {
        [Fact]
        public void CanGeneratePageLinks()
        {
            //Организация
            var urlHelper = new Mock<UrlHelper>();
            urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns("Test/Page1")
                .Returns("Test/Page2")
                .Returns("Test/Page3");
            var urlHelperFactory = new Mock<IUrlHelperFactory>();
            urlHelperFactory.Setup(f =>
                    f.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelper.Object);
            var helper = new PageLinkTagHelper(urlHelperFactory.Object)
            {
                PageModel = new PageInfo
                {
                    CurrentPage = 2,
                    TotalItems = 28,
                    ItemsPerPage = 10
                },
                PageAction = "Test"
            };
            var ctx = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), "");
            var content = new Mock<TagHelperContent>();
            var output = new TagHelperOutput("div", new TagHelperAttributeList(),
                (cache, encoder) => Task.FromResult(content.Object));

            //Действие
            helper.Process(ctx, output);

            //Утверждение
            Assert.Equal(@"<a href=""Test/Page1"">1</a>" 
                         + @"<a href=""Test/Page2"">2</a>" 
                         + @"<a href=""Test/Page3"">3</a>", output.Content.GetContent());
        }


        [Fact]
        public void CanSendPaginationViewModel()
        {
            //Организация
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new[]
            {
                new Book {Id = 1, Title = "T1"},
                new Book {Id = 2, Title = "T2"},
                new Book {Id = 3, Title = "T3"},
                new Book {Id = 4, Title = "T4"},
                new Book {Id = 5, Title = "T5"},
            });

            //Организация
            BookController controller = new BookController(mock.Object) {PageSize = 3};

            //Действие
            BooksListViewModel result = controller.List(2).ViewData.Model as BooksListViewModel;

            //Утверждение
            if (result == null) return;
            var pageInfo = result.PageInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
