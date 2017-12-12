using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static FileSearchBenchmark.EnumerateDirectoriesTests;
using static FileSearchBenchmark.EnumerateDirectoriesParallelTests;
using static FileSearchBenchmark.EnumerateFilesTests;
using static FileSearchBenchmark.EnumerateFilesParallelTest;
using static FileSearchBenchmark.EnumerateFilesParallelMaxDegreeTest;
using static FileSearchBenchmark.EnumerateFilesParallelMaxDegreeForceTest;
using static FileSearchBenchmark.EnumerateFilesQueueParallelTreeTest;
using static FileSearchBenchmark.EnumerateFilesConcurrentParallelTreeTest;
using static FileSearchBenchmark.EnumerateFilesStackParallelTreeTest;
using static FileSearchBenchmark.EnumerateFilesWithTasksTreesAndParallelTest;
using static FileSearchBenchmark.EnumerateFilesFastv1Test;
using static FileSearchBenchmark.EnumerateFilesFastv2Test;

namespace FileSearchBenchmark
{
    public class FileSearchBenchmark
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            string rootFolder = "C:\\";
            await Console.Out.WriteLineAsync("╔═════════════════════════════════════════╗");
            await Console.Out.WriteLineAsync("║ .NET Framework 4.7.1                    ║");
            await Console.Out.WriteLineAsync("║ FileSearch Benchmark                    ║");
            await Console.Out.WriteLineAsync("║                                  v1.0.0 ║");
            await Console.Out.WriteLineAsync("╚═════════════════════════════════════════╝");

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            await Console.Out.WriteLineAsync($"Priority set to {Process.GetCurrentProcess().PriorityClass}");

            //Directory.EnumerateFiles
            //await EnumerateDirectoriesTestAsync(rootFolder);
            //await EnumerateDirectoriesParallelTestAsync(rootFolder);

            //Directory.EnumerateFiles
            //await EnumerateFilesTestAsync(rootFolder);
            await EnumerateFilesParallelTestAsync(rootFolder);
            await EnumerateFilesParallelMaxDegreeTestAsync(rootFolder);
            await EnumerateFilesParallelMaxDegreeForceTestAsync(rootFolder);

            //Manual Recursive Implementations Handling Exceptions
            //await EnumerateFilesQueueParallelTreeTestAsync(rootFolder);
            //await EnumerateFilesConcurrentParallelTreeTestAsync(rootFolder);
            //await EnumerateFilesStackParallelTreeTestAsync(rootFolder);

            //Combination of Task, Recursion/Tree, Concurrent Objects and Parallel
            //await EnumerateFilesWithTasksTreesConcurrentParallelAsync(rootFolder);

            //3rd Party File Enumerators based WIN32 API
            //await EnumerateFilesFastv1TestAsync(rootFolder);
            await EnumerateFilesFastv2TestAsync(rootFolder);

            await Console.In.ReadLineAsync();
        }
    }
}
