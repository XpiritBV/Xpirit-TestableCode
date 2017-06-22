using Moq;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore.Sitecore82
{
    public static class FakeSitecoreItemFactory
    {
        public static Database CreateDbWithoutNewsRoot()
        {
            var databaseMock = new Mock<Database>();
            Item nullItem = null;
            databaseMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>())).Returns(nullItem);

            return databaseMock.Object;
        }

        public static Database CreateDbWithNewsRootAndWithoutNewsItems()
        {
            var databaseMock = new Mock<Database>();
            ItemList newsItems = new ItemList();
            Item newsRootItem = CreateNewsRootItemMock(databaseMock, newsItems);
            databaseMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>())).Returns(newsRootItem);

            return databaseMock.Object;
        }

        /// <summary>
        /// This factory method does not work as expected yet.
        /// </summary>
        /// <returns></returns>
        public static Database CreateDbWithNewsRootAndWithNewsItems()
        {
            var newsRootItemDatabaseMock = new Mock<Database>();
            ItemList newsItems = GetNewsItems(
                numberOfNewsItems: 3, 
                database: newsRootItemDatabaseMock.Object);
            Item newsRootItem = CreateNewsRootItemMock(newsRootItemDatabaseMock, newsItems);
            newsRootItemDatabaseMock.Setup(mock => mock.SelectSingleItem(It.IsAny<string>())).Returns(newsRootItem);

            return newsRootItemDatabaseMock.Object;
        }

        private static Item CreateNewsRootItemMock(Mock<Database> databaseMock, ItemList newsItems)
        {
            Mock<Item> newsRootItemMock = GetItemMock(Templates.NewsItemRoot.TemplateId, "NewsItemRoot", databaseMock.Object);
           
            // Need to mock the GetChildren method wich requires a valid ChildList object.
            var newsItemRootChildList = new ChildList(newsRootItemMock.Object, newsItems);
            newsRootItemMock.Setup(mock => mock.GetChildren()).Returns(newsItemRootChildList);

            return newsRootItemMock.Object;
        }

        private static ItemData GetItemData(ID itemId, string itemName, ID templateId)
        {
            ItemDefinition definition = new ItemDefinition(itemId, itemName, templateId, ID.Null);
            FieldList fields = new FieldList();

            return new ItemData(definition, Language.Invariant, Sitecore.Data.Version.First, fields);
        }

        private static ItemList GetNewsItems(int numberOfNewsItems, Database database)
        {
            ItemList newsItemList = new ItemList();
            for (int i = 0; i < numberOfNewsItems; i++)
            {
                Mock<Item> newsItemMock = GetItemMock(Templates.NewsItem.TemplateId, "NewsItem", database);
                newsItemList.Add(newsItemMock.Object);
            }
            return newsItemList;
        }

        private static Mock<Item> GetItemMock(ID templateId, string itemName, Database database)
        {
            ID itemId = ID.NewID;
            ItemData itemData = GetItemData(itemId, itemName, templateId);

            return new Mock<Item>(itemId, itemData, database);
        }
    }
}
