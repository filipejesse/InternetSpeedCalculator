using System;
using System.Diagnostics;

namespace InternetSpeedCalculator
{
    class Program
    {
        public static string File100Mb => "https://download.microsoft.com/download/B/1/7/B1783FE9-717B-4F78-A39A-A2E27E3D679D/ENU/x64/spPowerPivot16.msi";
        static void Main(string[] args)
        {
            var watch = new Stopwatch();

            byte[] data = DownloadTestFile(watch);

            var downloadSpeed = data.LongLength / watch.Elapsed.TotalSeconds;

            Console.WriteLine($"Download duration: {watch.Elapsed}");
            Console.WriteLine($"File size: {data.Length.ToString("N0")}");
            Console.WriteLine($"Speed: {downloadSpeed.ToString("N0")} bps ");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static byte[] DownloadTestFile(Stopwatch watch)
        {
            byte[] downloadedFile;
            using (var client = new System.Net.WebClient())
            {
                watch.Start();
                downloadedFile = client.DownloadData(File100Mb);
                watch.Stop();
            }

            return downloadedFile;
        }

    }
}
