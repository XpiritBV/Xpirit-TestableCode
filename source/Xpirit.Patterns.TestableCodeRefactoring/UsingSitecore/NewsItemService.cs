using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore
{
    public class NewsItemService
    {
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
            return Sitecore.Context.Database.SelectSingleItem(
                $"/sitecore/content/Home/*[@@templateid='{Templates.NewsItemRoot.TemplateId}']");
        }
    }
}
