using System;
using System.Threading.Tasks;
using static FileSearchBenchmarkCore.EnumerateDirectoriesTests;
using static FileSearchBenchmarkCore.EnumerateDirectoriesParallelTests;
using static FileSearchBenchmarkCore.EnumerateFilesTests;
using static FileSearchBenchmarkCore.EnumerateFilesParallelTest;
using static FileSearchBenchmarkCore.EnumerateFilesParallelMaxDegreeTest;
using static FileSearchBenchmarkCore.EnumerateFilesParallelMaxDegreeForceTest;
using static FileSearchBenchmarkCore.EnumerateFilesQueueParallelTreeTest;
using static FileSearchBenchmarkCore.EnumerateFilesConcurrentParallelTreeTest;
using static FileSearchBenchmarkCore.EnumerateFilesStackParallelTreeTest;
using static FileSearchBenchmarkCore.EnumerateFilesWithTasksTreesAndParallelTest;
using static FileSearchBenchmarkCore.EnumerateFilesFastv1Test;
using static FileSearchBenchmarkCore.EnumerateFilesFastv2Test;
using System.Diagnostics;

namespace FileSearchBenchmarkCore
{
    public class FileBenchmark
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            string rootFolder = "C:\\";
            await Console.Out.WriteLineAsync("╔═════════════════════════════════════════╗");
            await Console.Out.WriteLineAsync("║ NetCore v2.0.3 & NetStandard 2.0.1      ║");
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
