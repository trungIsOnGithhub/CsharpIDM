using System.Linq;

namespace Tree
{
    public class Utilities
    {
        public static IEnumerable<TreeNode> FlattenRootsByValue(
            IEnumerable<MultiTreeNode> rootList, string value )
        {
            return rootList
                        .SelectMany(
                            root => FlattenRootsByValue(root.Elements)
                        ).Concat(
                            rootList.Filter(root => root.Value == value)
                        );
        }
    }
}