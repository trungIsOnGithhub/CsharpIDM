using System.Collections.Generic;
using System.Threading;

namespace IDM.Core
{
    class DownloadManager
    {
        private readonly static int MAX_WORKER	= 8;
        private readonly static int MIN_WORKER_DOWNLOAD_SIZE = 1024 * 1024; // 1MB

        private long downloadId;

        private DownloadWorker[] workers;
        private Thread[] workerThreads;
        private int busyWorker = 0;

        private FileMetadata metadata;
        private IList<PacketMetadata> packetMetadataList;

        private string downloadURL;
        private string filePath;

        private long numCompletedPacket = 0l;
        private float downloadSpeed	= 0.0f;
    }

    class DownloadWorker 
    {

    }
}