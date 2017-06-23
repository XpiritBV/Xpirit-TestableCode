using Sitecore.Data;
using Sitecore.Data.Items;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters
{
    public class ItemProvider : IItemProvider
    {
        public IItemAdapter GetItem(ID itemId)
        {
            var item = GetSitecoreItem(itemId);

            return item != null ? new ItemAdapter(item) : null;
        }

        public IItemAdapter SelectSingleItem(string query)
        {
            var item = SelectSingleSitecoreItem(query);

            return item != null ? new ItemAdapter(item) : null;
        }

        private Item GetSitecoreItem(ID itemId)
        {
            return Sitecore.Context.Database.GetItem(itemId);
        }

        private Item SelectSingleSitecoreItem(string query)
        {
            return Sitecore.Context.Database.SelectSingleItem(query);
        }
    }
}
