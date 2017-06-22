using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.FakeDB
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
            /* Never use a content path directly in code like this example. 
               This is not production quality code!
             */
            return Sitecore.Context.Database.SelectSingleItem(
                $"/sitecore/content/Home/*[@@templateid='{Templates.NewsItemRoot.TemplateId}']");
        }
    }
}
