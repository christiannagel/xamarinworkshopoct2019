using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace BooksLib.Tests
{
    public class SampleBooksServiceTests
    {
        public class MockingLogger<SampleBooksService> : ILogger<SampleBooksService>
        {
            public IDisposable BeginScope<TState>(TState state) => null;
            public bool IsEnabled(LogLevel logLevel) => false;
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) { }
        }

        [Fact]
        public async Task GetBooksAsync()
        {
            // AAA

            // Arrange
            int expectedBooks = 5;
            var service = new SampleBooksService(new MockingLogger<SampleBooksService>());
            // Act
            var books = await service.GetBooksAsync();
            int actualBooks = books.Count();
            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }
    }
}
