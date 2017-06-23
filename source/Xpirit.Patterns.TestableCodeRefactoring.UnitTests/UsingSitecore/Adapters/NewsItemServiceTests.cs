using FluentAssertions;
using NUnit.Framework;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore.Adapters
{
    [TestFixture]
    public class NewsItemServiceTests
    {
        [Test]
        public void GetNewsItems_WithInvalidNewsRoot_ReturnsEmptyList()
        {
            // Arrange
            IItemProvider itemProvider = ItemProviderFactory.CreateItemProviderWithoutNewsItemRoot();
            var newsItemService = new NewsItemService(itemProvider);

            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetNewsItems_WithValidNewsRootAndNoNewsItems_ReturnsEmptyList()
        {
            // Arrange
            IItemProvider itemProvider = ItemProviderFactory.CreateItemProviderWithNewsItemRootWithoutNewsItems();
            NewsItemService newsItemService = GetNewsItemService(itemProvider);
            
            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetNewsItems_WithValidNewsRootAndNewsItems_ReturnsNewsItems()
        {
            // Arrange
            var itemProvider = ItemProviderFactory.CreateItemProviderWithNewsItemRootWithNewsItems(
                numberOfNewsItems: 3);
            var newsItemService = GetNewsItemService(itemProvider);
         
            // Act
            var result = newsItemService.GetNewsItems();

            // Assert
            result.Should().NotBeEmpty();
        }

        private NewsItemService GetNewsItemService(IItemProvider itemProvider)
        {
            return new NewsItemService(itemProvider);
        }
    }
}
