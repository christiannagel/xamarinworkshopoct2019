using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksLib.Tests
{
    public class MainPageViewModelTests
    {
        public class MockBooksService : IBooksService
        {
            public Task AddBookAsync(Book book) => throw new NotImplementedException();
            public Task<Book> GetBookAsync(int id) => throw new NotImplementedException();
            public Task<IEnumerable<Book>> GetBooksAsync()
                => Task.FromResult(
                Enumerable.Range(1, 10)
                    .Select(x =>
                    new Book { Title = $"title{x}", Publisher = "pub" }));

        }

        [Fact]
        public async Task InitAsync()
        {
            // arrange
            int expected = 10;
            var vm = new MainPageViewModel(new MockBooksService());
            // act
            await vm.InitAsync();
            var books = vm.Books;
            int actual = books.Count();
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FooArgumentNullException()
        {
            var vm = new MainPageViewModel(new MockBooksService());

            Assert.Throws<ArgumentNullException>(() =>
            {
                vm.Foo(null);
            });
        }

        [Fact]
        public void FooConvertInputToLower()
        {
            var vm = new MainPageViewModel(new MockBooksService());
            string expected = "abc";
            string actual = vm.Foo("ABC");
            Assert.Equal(expected, actual);

        }
    }
}
