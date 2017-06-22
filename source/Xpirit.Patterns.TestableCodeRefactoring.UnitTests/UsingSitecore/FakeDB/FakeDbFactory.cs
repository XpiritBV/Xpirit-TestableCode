using Moq;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore;
using Sitecore.Data;
using Sitecore.FakeDb;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingSitecore
{
    public static class FakeDbFactory
    {
        public static Db CreateDbWithoutNewsRoot()
        {
            return new Db { new DbItem("Home") };
        }

        public static Db CreateDbWithNewsRootAndWithoutNewsItems()
        {
            return new Db
            {
                new DbTemplate("NewsItemRoot", Templates.NewsItemRoot.TemplateId),
                new DbItem("Home")
                {
                    new DbItem("News", ID.NewID, Templates.NewsItemRoot.TemplateId)
                }
            };
        }

        public static Db CreateDbWithNewsRootAndWithNewsItems()
        {
            return new Db
            {
                new DbTemplate("NewsItemRoot", Templates.NewsItemRoot.TemplateId),
                new DbTemplate("NewsItem", Templates.NewsItem.TemplateId),
                new DbItem("Home")
                {
                    new DbItem("News", ID.NewID, Templates.NewsItemRoot.TemplateId)
                    {
                        new DbItem(It.IsAny<string>(), ID.NewID, Templates.NewsItem.TemplateId),
                        new DbItem(It.IsAny<string>(), ID.NewID, Templates.NewsItem.TemplateId),
                        new DbItem(It.IsAny<string>(), ID.NewID, Templates.NewsItem.TemplateId)
                    }
                }
            };
        }
    }
}
