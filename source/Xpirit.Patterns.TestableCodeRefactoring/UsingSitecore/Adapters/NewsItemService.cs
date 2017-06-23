using System.Collections.Generic;
using System.Linq;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters
{
    public class NewsItemService
    {
        private readonly IItemProvider _itemProvider;

        public NewsItemService(IItemProvider itemProvider)
        {
            _itemProvider = itemProvider;
        }
        public IEnumerable<IItemAdapter> GetNewsItems()
        {
            var newsItemRoot = GetNewsItemRoot();
            if (newsItemRoot == null)
            {
                return new List<IItemAdapter>();
            }

            return newsItemRoot.GetChildren() 
                .Where(item => item.TemplateId == Templates.NewsItem.TemplateId);
        }

        private IItemAdapter GetNewsItemRoot()
        {
            /* Never use a content path directly in code like this example. 
               This is not production quality code!
             */
            return _itemProvider.SelectSingleItem(
                $"/sitecore/content/Home/*[@@templateid='{Templates.NewsItemRoot.TemplateId}']");
        }
    }
}
