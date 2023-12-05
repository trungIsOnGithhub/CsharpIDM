using System.Linq;

namespace Tree
{
    public class TreeNode
    {
        public string Value { get; set; }
        public TreeNode Parent { get; set; }
    }

    public class MultiTreeNode : TreeNode
    {
        public IEnumerable<MultiTreeNode> Childs;

        public IEnumerable<string> GetChildsName()
        {
            return (from child in Childs select child.Value);
        }
    }

    public class FileTreeNode : MultiTree
    {
        public IEnumerable<FileTreeNode> Childs;
        public double sizeMB;
    }



    public class MultiTree
    {
        public MultiTreeNode Root { get; set; }
    }

    public class FileTree
    {
        public FileTreeNode Root { get; set; }

        public double getTotalSizeMB()
        {
            return FileTree.getTotalSizeMB(this.Root);
        }

        public static double getTotalSizeMB(FileTreeNode root)
        {
            return root.sizeMB +
                    root.Childs.Sum(root => getTotalSizeMB(root));
        }
    }
}