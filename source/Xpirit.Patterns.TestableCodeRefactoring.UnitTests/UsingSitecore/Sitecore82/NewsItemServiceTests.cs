using FluentAssertions;
using NUnit.Framework;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Sitecore8._2;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore.Sitecore82
{
    [TestFixture]
    public class NewsItemServiceTests
    {
        [Test]
        public void GetNewsItems_WithInvalidNewsRoot_ReturnsEmptyList()
        {
            // Arrange
            var newsItemService = new NewsItemService
            {
                Database = FakeSitecoreItemFactory.CreateDbWithoutNewsRoot()
            };

            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetNewsItems_WithValidNewsRootAndNoNewsItems_ReturnsEmptyList()
        {
            // Arrange
            var newsItemService = new NewsItemService
            {
                Database = FakeSitecoreItemFactory.CreateDbWithNewsRootAndWithoutNewsItems()
            };
           
            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().BeEmpty();
            
        }

        [Test]
        [Ignore("Because factory method for fake Database is not working as expected.")]
        public void GetNewsItems_WithValidNewsRootAndNewsItems_ReturnsNewsItems()
        {
            // Arrange
            var newsItemService = new NewsItemService
            {
                Database = FakeSitecoreItemFactory.CreateDbWithNewsRootAndWithNewsItems()
            };
            
            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().NotBeEmpty();
        }
    }
}
