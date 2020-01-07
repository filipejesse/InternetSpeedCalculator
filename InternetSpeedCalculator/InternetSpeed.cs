using System.Diagnostics;

namespace InternetSpeedCalculator
{
    public static class InternetSpeed
    {
        // Links from: https://downloadtestfiles.com/

        static string File50Mb => "https://download.microsoft.com/download/8/7/D/87D36A01-1266-4FD3-924C-1F1F958E2233/Office2010DevRefs.exe";

        static string File100Mb => "https://download.microsoft.com/download/B/1/7/B1783FE9-717B-4F78-A39A-A2E27E3D679D/ENU/x64/spPowerPivot16.msi";

        static string File500Mb => "https://download.microsoft.com/download/0/A/F/0AFB5316-3062-494A-AB78-7FB0D4461357/windows6.1-KB976932-IA64.exe";

        public static string CalculateDownloadInternetSpeed()
        {
            var watch = new Stopwatch();
            byte[] data = DownloadTestFile(File100Mb, watch);
            var downloadSpeed = (data.LongLength / watch.Elapsed.TotalSeconds).ToString("N0");

            return $"{ downloadSpeed } bps";
        }

        private static byte[] DownloadTestFile(string testFile, Stopwatch watch)
        {
            byte[] downloadedFile;
            using (var client = new System.Net.WebClient())
            {
                watch.Start();
                downloadedFile = client.DownloadData(testFile);
                watch.Stop();
            }

            return downloadedFile;
        }
    }
}
