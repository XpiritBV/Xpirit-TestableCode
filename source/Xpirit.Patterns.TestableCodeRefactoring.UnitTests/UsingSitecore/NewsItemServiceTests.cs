using FluentAssertions;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore
{
    [TestFixture]
    public class NewsItemServiceTests
    {
        [Test]
        [Category("Requires Sitecore license")]
        public void GetNewsItems_WithInvalidNewsRoot_ReturnsEmptyList()
        {
            // Arrange
            var newsItemService = new NewsItemService();
            using (var db = FakeDbFactory.CreateDbWithoutNewsRoot())
            {
                // Act
                var result = newsItemService.GetNewsItems();

                // Assert
                result.Should().BeEmpty();
            }
        }

        [Test]
        [Category("Requires Sitecore license")]
        public void GetNewsItems_WithValidNewsRootAndNoNewsItems_ReturnsEmptyList()
        {
            // Arrange
            var newsItemService = new NewsItemService();
            using (var db = FakeDbFactory.CreateDbWithNewsRootAndWithoutNewsItems())
            {
                // Act
                var result = newsItemService.GetNewsItems();

                // Assert
                result.Should().BeEmpty();
            }
        }

        [Test]
        [Category("Requires Sitecore license")]
        public void GetNewsItems_WithValidNewsRootAndNewsItems_ReturnsNewsItems()
        {
            // Arrange
            var newsItemService = new NewsItemService();
            using (var db = FakeDbFactory.CreateDbWithNewsRootAndWithNewsItems())
            {
                // Act
                var result = newsItemService.GetNewsItems();

                // Assert
                result.Should().NotBeEmpty();
            }
        }
    }
}
