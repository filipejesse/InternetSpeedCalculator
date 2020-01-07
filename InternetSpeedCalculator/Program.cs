using System;

namespace InternetSpeedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting test...");
            Console.WriteLine($"Speed: {InternetSpeed.CalculateDownloadInternetSpeed()}");
        }
    }
}
