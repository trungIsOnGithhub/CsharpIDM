namespace IDM.Core
{
    /**
    * NEW - Download process has not initialized yet.
    * READY - Download ready to begin. Can be set only once.
    * DOWNLOADING - Download is in progress.
    * COMPLETED - All file packet has finished download successfully.
    * PAUSED - Download is paused explicitly.
    * ERROR - 
    */
    enum DownloadStatus
    {
        NEW, READY, DOWNLOADING, COMPLETED, PAUSED, ERROR
    }
}