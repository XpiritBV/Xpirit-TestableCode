using Sitecore.Data;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingSitecore.Adapters.Interfaces
{
    public interface IItemProvider
    {
        IItemAdapter GetItem(ID itemId);

        IItemAdapter SelectSingleItem(string query);
    }
}
