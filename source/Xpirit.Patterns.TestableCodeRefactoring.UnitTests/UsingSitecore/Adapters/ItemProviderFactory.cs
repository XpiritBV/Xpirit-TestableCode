using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore.Adapters
{
    public static class ItemProviderFactory
    {
        public static IItemProvider CreateItemProviderWithoutNewsItemRoot()
        {
            var itemProviderMock = new Mock<IItemProvider>();
            IItemAdapter nullNewsRootItem = null;
            itemProviderMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>()))
                .Returns(nullNewsRootItem);

            return itemProviderMock.Object;
        }

        public static IItemProvider CreateItemProviderWithNewsItemRootWithoutNewsItems()
        {
            var newsItemRootMock = new Mock<IItemAdapter>();
            List<IItemAdapter> emptyNewsItemCollection = new List<IItemAdapter>();
            newsItemRootMock.Setup(mock => mock.GetChildren()).Returns(emptyNewsItemCollection);

            var itemProviderMock = new Mock<IItemProvider>();
            itemProviderMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>()))
                .Returns(newsItemRootMock.Object);

            return itemProviderMock.Object;
        }

        public static IItemProvider CreateItemProviderWithNewsItemRootWithNewsItems(int numberOfNewsItems)
        {
            IEnumerable<IItemAdapter> newsItemCollection = GetNewsItemAdapterCollection(numberOfNewsItems);

            var newsItemRootMock = new Mock<IItemAdapter>();
            newsItemRootMock.Setup(mock => mock.GetChildren()).Returns(newsItemCollection);

            var itemProviderMock = new Mock<IItemProvider>();
            itemProviderMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>()))
                .Returns(newsItemRootMock.Object);

            return itemProviderMock.Object;
        }

        private static IEnumerable<IItemAdapter> GetNewsItemAdapterCollection(int numberOfNewsItems)
        {
            var newsItemCollection = new List<IItemAdapter>();
            for (int i = 0; i < numberOfNewsItems; i++)
            {
                var newsItemMock = new Mock<IItemAdapter>();
                newsItemMock.SetupGet(mock => mock.TemplateId).Returns(Templates.NewsItem.TemplateId);
                newsItemCollection.Add(newsItemMock.Object);
            }

            return newsItemCollection;
        }
    }
}
