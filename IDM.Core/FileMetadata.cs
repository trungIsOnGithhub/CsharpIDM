namespace IDM.Core
{
    class FileMetadata
    {
        private long startTimestamp;
        private long endTimestamp;

        private long downloadId;
        private string path;

        public FileMetadata(long downloadId, long startTimestamp, string path) {
            this.downloadId	= downloadId;
            this.startTimestamp = startTimestamp;
            this.path = path;
        }


        public long StartTime
        {
            get { return this.startTimestamp; }
        }

        public long EndTime
        {
            get { return this.endTimestamp; }
            set { this.endTimestamp = value; }
        }
    }
}