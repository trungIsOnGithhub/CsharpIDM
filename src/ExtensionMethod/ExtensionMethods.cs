using ConsoleApplication;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static string Name(this string filePath)
        {
            return ObjectManager.RemovePathFromName(filePath);
        }

        public static string FileSize(this string filePath)
        {
            return Utilities.SelectAppropriateFileSizeFormat(
                ObjectManager.GetSizeOfFile(filePath)
            );
        }

        public static string FolderSize(this string folderPath)
        {
            return Utilities.SelectAppropriateFileSizeFormat(
                ObjectManager.GetSizeOfDirectory(folderPath)
            );
        }

        public static string LastAccess(this string path)
        {
            return ObjectManager.GetTimeStampForLastAccess(path);
        }
    }
}