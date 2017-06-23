using System.Collections.Generic;
using System.Linq;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters
{
    public class ItemAdapter : IItemAdapter
    {
        public ItemAdapter(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            this.InnerItem = item;
        }

        public string DisplayName
        {
            get { return InnerItem.DisplayName; }
        }

        public ID Id
        {
            get { return InnerItem.ID; }
        }

        public Item InnerItem
        {
            get;
            private set;
        }

        public ID TemplateId
        {
            get { return InnerItem.TemplateID; }
        }

        public string this[string fieldName]
        {
            get { return InnerItem.Fields[fieldName].Value; }
        }


        public IEnumerable<IItemAdapter> GetChildren()
        {
            return InnerItem.GetChildren().Select(item => new ItemAdapter(item)).ToList() ;
        }
    }
}
