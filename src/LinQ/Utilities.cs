using System.Linq;

namespace Tree
{
    public class Utilities
    {
        public static IEnumerable<MultiTreeNode> FlattenRootsByValue(
            IEnumerable<MultiTreeNode> rootList, string value )
        {
            return rootList
                        .SelectMany(
                            root => FlattenRootsByValue(root.Childs, value)
                        ).Concat(
                            rootList.Where(root => root.Value == value)
                        );
        }
    }
}