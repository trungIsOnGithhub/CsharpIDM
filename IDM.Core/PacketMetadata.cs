namespace IDM.Core
{
    class PacketMetadata
    {
        private long startTimestamp;
        private long endTimestamp;

        private long downloadId;
        private int id;
        private string path;

        public PacketMetadata(long downloadId, int id, long startTimestamp, string path) {
            this.downloadId	= downloadId;
            this.id	= id;
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