using System.Collections.Generic;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces
{
    public interface IItemAdapter
    {
        string DisplayName { get; }

        ID Id { get; }

        Item InnerItem { get; }

        ID TemplateId { get; }

        string this[string fieldName] { get; }

        IEnumerable<IItemAdapter> GetChildren();
    }
}
