using System.Linq;

namespace Tree
{
    interface ITreeNode : INullable
    {
        public string Name;
        public ITreeNode Parent;
    }

    class MultiTreeNode : ITreeNode
    {
        public IEnumerable<MultiTreeNode> Childs;

        public IEnumerable<string> GetChildsName()
        {
            return (from child in Childs select child.Name);
        }
    }

    class FileTreeNode : MultiTree
    {
        public double sizeMB;
    }



    class MultiTree
    {
        public MultiTreeNode Root { get; set; };
    }

    class FileTree
    {
        public FileTreeNode Root { get; set; };

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