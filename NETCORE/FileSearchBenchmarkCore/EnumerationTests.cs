using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static HouseofCat.LibraryCore.FileEnumerators;
using static HouseofCat.LibraryCore.DirectoryEnumerators;
using static HouseofCat.LibraryCore.FastDirectoryEnumerator;
using static HouseofCat.LibraryCore.FastFileInfo;
using HouseofCat.LibraryCore;

namespace FileSearchBenchmarkCore
{
    public static class EnumerateDirectoriesTests
    {
        public static async Task EnumerateDirectoriesTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Directories Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateDirectoriesAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Directories Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateDirectoriesAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Directories in ({rootFolder}) Begins...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = EnumerateDirectories(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Directories Enumerated: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateDirectoriesParallelTests
    {
        public static async Task EnumerateDirectoriesParallelTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Directories w/ Parallel Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateDirectoriesParallelAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Directories w/ Parallel Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateDirectoriesParallelAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Directories in ({rootFolder}) Begins...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = EnumerateDirectoriesInParallel(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Directories Enumerated: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateFilesTests
    {
        public static async Task EnumerateFilesTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = FileEnumerators.EnumerateFiles(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateFilesParallelTest
    {
        public static async Task EnumerateFilesParallelTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesParallelAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesParallelAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = EnumerateFilesInParallel(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateFilesParallelMaxDegreeTest
    {
        public static async Task EnumerateFilesParallelMaxDegreeTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Max Degree Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesParallelMaxDegreeAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Max Degree Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesParallelMaxDegreeAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = EnumerateFilesInParallelMaxDegree(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateFilesParallelMaxDegreeForceTest
    {
        public static async Task EnumerateFilesParallelMaxDegreeForceTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesParallelMaxDegreeForceAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesParallelMaxDegreeForceAsync(string rootFolder, int iteration)
        {
            var t = await Task.Run(async () =>
            {
                await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
                Stopwatch sw = Stopwatch.StartNew();

                var dirs = new List<string>();
                dirs = EnumerateFilesInParallelMaxDegreeForced(rootFolder, "*", SearchOption.AllDirectories).ToList();
                sw.Stop();
                var seconds = sw.ElapsedMilliseconds / 1000.0;

                await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
                await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
                await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

                return seconds;
            });

            return t;
        }
    }

    public static class EnumerateFilesQueueParallelTreeTest
    {
        public static async Task EnumerateFilesQueueParallelTreeTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Queue Parallel Tree Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesQueueParallelTreeAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Queue Parallel Tree Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesQueueParallelTreeAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<string>();
            dirs = (await GetFilesInQueueParallelAsync(rootFolder, "*")).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }

    public static class EnumerateFilesConcurrentParallelTreeTest
    {
        public static async Task EnumerateFilesConcurrentParallelTreeTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Concurrent Parallel Tree Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesConcurrentParallelTreeAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Concurrent Parallel Tree Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesConcurrentParallelTreeAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<string>();
            dirs = (await GetFilesInConcurrentParallelAsync(rootFolder, "*")).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }

    public static class EnumerateFilesStackParallelTreeTest
    {
        public static async Task EnumerateFilesStackParallelTreeTestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Stack Parallel Tree Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesStackParallelTreeAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Stack Parallel Tree Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesStackParallelTreeAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<string>();
            dirs = (await GetFilesInStackParallelAsync(rootFolder, "*")).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }

    public static class EnumerateFilesWithTasksTreesAndParallelTest
    {
        public static async Task EnumerateFilesWithTasksTreesConcurrentParallelAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Task, Trees, And Parallel Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesWithTasksTreesConcurrentParallelAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ Task, Trees, And Parallel Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesWithTasksTreesConcurrentParallelAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder})...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<string>();
            dirs = (await EnumerateFilesWithTasksTreesConcurrentAndParallelAsync(rootFolder, "*")).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }

    public static class EnumerateFilesFastv1Test
    {
        public static async Task EnumerateFilesFastv1TestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ FastDirectoryEnumerator Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesFastAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ FastDirectoryEnumerator Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesFastAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder}) Begins...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<FileData>();
            dirs = (await EnumerateFilesFastv1Async(rootFolder, "*", SearchOption.AllDirectories)).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Enumerated: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }

    public static class EnumerateFilesFastv2Test
    {
        public static async Task EnumerateFilesFastv2TestAsync(string rootFolder)
        {
            await Console.Out.WriteLineAsync($"Enumerate Files w/ FastFileInfo Enumerator Test Begins.");
            var seconds = 0.0;
            var limit = 5;
            for (int i = 0; i < limit; i++)
            {
                seconds += await EnumerateFilesFastAsync(rootFolder, i);
            }
            await Console.Out.WriteLineAsync($"Enumerate Files w/ FastFileInfo Enumerator Test Complete.\n\tTotal Time: {seconds}s\tAvg. Time: {seconds / limit}s\n");
        }

        private static async Task<double> EnumerateFilesFastAsync(string rootFolder, int iteration)
        {
            await Console.Out.WriteLineAsync($"\tTest {iteration}: Finding Files in ({rootFolder}) Begins...");
            Stopwatch sw = Stopwatch.StartNew();

            var dirs = new List<FastFileInfo>();
            dirs = (await EnumerateFilesFastv2Async(rootFolder, "*", SearchOption.AllDirectories)).ToList();
            sw.Stop();
            var seconds = sw.ElapsedMilliseconds / 1000.0;

            await Console.Out.WriteLineAsync($"\t\t== Test {iteration} Summary ==");
            await Console.Out.WriteLineAsync($"\t\t   Files Found: {dirs.Count}");
            await Console.Out.WriteLineAsync($"\t\t   Elapsed Time: {seconds}s");

            return seconds;
        }
    }
}
