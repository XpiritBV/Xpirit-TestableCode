using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Sitecore8._2
{
    public class NewsItemService
    {
        private Database _database;
        public Database Database
        {
            get => _database ?? Sitecore.Context.Database;
            set => _database = value;
        }

        public IEnumerable<Item> GetNewsItems()
        {
            var newsItemRoot = GetNewsItemRoot();
            if (newsItemRoot == null)
            {
                return new List<Item>();
            }



            return newsItemRoot.GetChildren() 
                .Where(item => item.TemplateID == Templates.NewsItem.TemplateId);
        }

        private Item GetNewsItemRoot()
        {
            return Database.SelectSingleItem(
                $"/sitecore/content/Home/*[@@templateid='{Templates.NewsItemRoot.TemplateId}']");
        }
    }
}
