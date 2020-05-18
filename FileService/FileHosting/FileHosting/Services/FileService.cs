using System;
using System.IO;
using System.ServiceModel;
using FileHosting.Interfaces;

using System.Diagnostics;

namespace FileHosting.Services
{
    [ServiceBehavior(
        //InstanceContextMode = InstanceContextMode.PerCall,
        //ConcurrencyMode = ConcurrencyMode.Multiple,
        //AutomaticSessionShutdown = true,
        MaxItemsInObjectGraph = 10000,
        IncludeExceptionDetailInFaults = true
        )]
    internal class FileService : IFileService
    {
        public DateTime GetServiceTime() => DateTime.Now;

        public DriveInfo[] GetDrives() => DriveInfo.GetDrives();

        public FileInfo[] GetFiles(string Path) => new DirectoryInfo(Path).GetFiles();

        public DirectoryInfo[] GetDirectories(string Path) => new DirectoryInfo(Path).GetDirectories();

        public int StartProcess(string Path, string Args)
        {
            //var process_info = new ProcessStartInfo();
            var process = Process.Start(Path, Args);

            return process?.Id ?? -1;
        }
    }
}
