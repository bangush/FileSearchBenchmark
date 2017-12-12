# FileSearchBenchmark

Demonstrating the performance difference of a number of methods for File & Folder enumeration. I compare implementation 
performance, Collection type, and Framework / Core Version.  

Includes pre-built Tests:
 * EnumerateDirectoriesTestAsync
 * EnumerateDirectoriesParallelTestAsync
 * EnumerateFilesTestAsync
 * EnumerateFilesParallelTestAsync
 * EnumerateFilesParallelMaxDegreeTestAsync
 * EnumerateFilesParallelMaxDegreeForceTestAsync
 * EnumerateFilesQueueParallelTreeTestAsync
 * EnumerateFilesConcurrentParallelTreeTestAsync
 * EnumerateFilesStackParallelTreeTestAsync
 * EnumerateFilesWithTasksTreesConcurrentParallelAsync
 * EnumerateFilesFastv1TestAsync
 * EnumerateFilesFastv2TestAsync
 
There are more enumerating functions than there are tests, so more tests can be written.  
 
Includes the entire Library I use for projects so go crazy! The code comes in standard 4.7.1 and NetCore 2.0.3 & 
NetStandard 2.0.1. The Library code includes sources/citations. I use two 3rd party File Enumerators that used to 
be pretty decent implementations using the WIN32 API back in the day. The main projects are dependent on the Library and 
LibraryCore projects being built first. Library and LibraryCore are virtually identical. Queues in NetCore/NetStandard 
have a TryDequeue which I utilized. The reason why there are two full Library Projects identically maintained is for 
your convenience. The citations/sources are included in the source for code borrowed.

For a more detailed and technical explanation on the other methods please visit my website (https://houseofcat.io)  
 * Navigate to Software
 * Click FileSearchBenchmark

### Last Update
December 12th, 2017 - Initial Commit  

### How To Setup As Is
1. Get Code.
2. Run Visual Studio 2017 as Administrator
3. Open SLN/Code, Restore Packages.
4. Run Benchmark (`Release x64 Configuration`)

### How To Setup With A Custom Root Folder (i.e. Not C:\)
1. Get Code.
2. Run Visual Studio 2017 as Administrator
3. Open SLN/Code, Restore Packages.
4. Edit `FileSearchBenchmark\Program.cs` and change `rootFolder` in `MainAsync`.
5. Run Benchmark (`Release x64 Configuration`)

### How To Run Other Tests
1. Get Code.
2. Run Visual Studio 2017 as Administrator
3. Open SLN/Code, Restore Packages.
4. Edit `FileSearchBenchmark\Program.cs` and uncomment some of the other pre-written tests.
5. Run Benchmark (`Release x64 Configuration`)

### How To Create Tests
1. Get Code.
2. Run Visual Studio 2017 as Administrator
3. Open SLN/Code, Restore Packages.
4. Edit `FileSearchBenchmark\EnumerationTests.cs` and follow the wrapper design pattern.
   * public static class (contains the Task Test)
   * public static Task for the Test (calls EnumeratorTask)
   * public static Task for the Enumerator
   * add reference to static class in `FileSearchBenchmark\Program.cs`
   * add an await for new pulibc static Task in `MainAsync` (`FileSearchBenchmark\Program.cs`.
5. Run Benchmark (Release x64 Configuration)

### How Do I Add New Enumerators
1. Get Code.
2. Run Visual Studio 2017 as Administrator
3. Open SLN/Code, Restore Packages.
4. Edit `Library\FileEnumerators.cs` and go crazy.
5. Follow the `How To Create Tests` steps above to integrate your code with a test pattern.
5. Run Benchmark (`Release x64 Configuration`)

#### Known Issues
EnumerateFilesFastv1TestAsync is prone to StackOverflowException.  
  * I will eventually clean it up since I think there is hope for it.  

#### Output An EXE For NetCore Console App
* Open PowerShell/CMD (As Administrator)  
* Navigate to your Core Project (`cd "C:\Code\FileSearchBenchmark\"`)
* Execute following command `dotnet publish -c Release -r win10-x64`  

#### NuGet / Dependencies
AsyncEnumerator by Serge Semenov (tyrotoxin).  
https://github.com/tyrotoxin/AsyncEnumerable  
https://www.nuget.org/packages/AsyncEnumerator/  

#### Consistently Predictable Results
Roslyn is consistently faster, although the results can be sporadic.  
For Best Results
 * Isolate tests to a drive that the OS doesn't actively use.  
 * Run as Administrator (Visual Studio 2017)

#### Results

Test Averages                                            | 4.7.1    |  NetCore |  Imp. % |
--- | --- | --- | --- |
Enumerate Files w/ Parallel                              | 11.5338s |  9.2248s | 20.194% |
Enumerate Files w/ Parallel Max Degree                   | 10.7578s |  7.9718s | 25.897% |
Enumerate Files w/ Parallel Max Degree (Forced Parallel) | 11.3502s |   9.172s | 19.191% |
Enumerate Files w/ FastFileInfo Enumerator               | 10.1104s |  9.4074s | 6.953%  |

Test Bed  
System: `Windows 10 (x64) Pro - Fall Creator's Update`  
CPU: `i7 4790K @ 4.4GHz`  
DSK: `256GB SSD Crucial MX300`  
Root: `C:\`

<details>
<summary>.NET Framework Results</summary>
<pre>
╔═════════════════════════════════════════╗
║ .NET Framework 4.7.1                    ║
║ FileSearch Benchmark                    ║
║                                  v1.0.0 ║
╚═════════════════════════════════════════╝
Priority set to High
Enumerate Files w/ Parallel Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013237
                   Elapsed Time: 11.615s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.282s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.303s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.938s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.531s
Enumerate Files w/ Parallel Test Complete.
        Total Time: 57.669s     Avg. Time: 11.5338s

Enumerate Files w/ Parallel Max Degree Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.255s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.162s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.292s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 11.153s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013238
                   Elapsed Time: 8.927s
Enumerate Files w/ Parallel Max Degree Test Complete.
        Total Time: 53.789s     Avg. Time: 10.7578s

Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013240
                   Elapsed Time: 11.263s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013241
                   Elapsed Time: 11.151s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013242
                   Elapsed Time: 11.146s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013266
                   Elapsed Time: 11.926s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013266
                   Elapsed Time: 11.265s
Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Complete.
        Total Time: 56.751s     Avg. Time: 11.3502s

Enumerate Files w/ FastFileInfo Enumerator Test Begins.
        Test 0: Finding Files in (C:\) Begins...
                == Test 0 Summary ==
                   Files Found: 1013266
                   Elapsed Time: 10.079s
        Test 1: Finding Files in (C:\) Begins...
                == Test 1 Summary ==
                   Files Found: 1013268
                   Elapsed Time: 9.987s
        Test 2: Finding Files in (C:\) Begins...
                == Test 2 Summary ==
                   Files Found: 1013268
                   Elapsed Time: 10.196s
        Test 3: Finding Files in (C:\) Begins...
                == Test 3 Summary ==
                   Files Found: 1013263
                   Elapsed Time: 9.941s
        Test 4: Finding Files in (C:\) Begins...
                == Test 4 Summary ==
                   Files Found: 1013263
                   Elapsed Time: 10.349s
Enumerate Files w/ FastFileInfo Enumerator Test Complete.
        Total Time: 50.552s     Avg. Time: 10.1104s
</pre>
</details>
<details>
<summary>NetCore 2.0.3 & NetStandard 2.0.1 Results</summary>
<pre>
╔═════════════════════════════════════════╗
║ NetCore v2.0.3 & NetStandard 2.0.1      ║
║ FileSearch Benchmark                    ║
║                                  v1.0.0 ║
╚═════════════════════════════════════════╝
Priority set to High
Enumerate Files w/ Parallel Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.531s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.255s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.115s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013293
                   Elapsed Time: 8.922s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013293
                   Elapsed Time: 9.301s
Enumerate Files w/ Parallel Test Complete.
        Total Time: 46.124s     Avg. Time: 9.2248s

Enumerate Files w/ Parallel Max Degree Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013293
                   Elapsed Time: 9.495s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013295
                   Elapsed Time: 7.386s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.202s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 6.754s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 7.022s
Enumerate Files w/ Parallel Max Degree Test Complete.
        Total Time: 39.859s     Avg. Time: 7.9718s

Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Begins.
        Test 0: Finding Files in (C:\)...
                == Test 0 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.407s
        Test 1: Finding Files in (C:\)...
                == Test 1 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 8.944s
        Test 2: Finding Files in (C:\)...
                == Test 2 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.188s
        Test 3: Finding Files in (C:\)...
                == Test 3 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.12s
        Test 4: Finding Files in (C:\)...
                == Test 4 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.201s
Enumerate Files w/ Parallel Max Degree (Forced Parallel) Test Complete.
        Total Time: 45.86s      Avg. Time: 9.172s

Enumerate Files w/ FastFileInfo Enumerator Test Begins.
        Test 0: Finding Files in (C:\) Begins...
                == Test 0 Summary ==
                   Files Found: 1013291
                   Elapsed Time: 9.558s
        Test 1: Finding Files in (C:\) Begins...
                == Test 1 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.11s
        Test 2: Finding Files in (C:\) Begins...
                == Test 2 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.681s
        Test 3: Finding Files in (C:\) Begins...
                == Test 3 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.145s
        Test 4: Finding Files in (C:\) Begins...
                == Test 4 Summary ==
                   Files Found: 1013292
                   Elapsed Time: 9.543s
Enumerate Files w/ FastFileInfo Enumerator Test Complete.
        Total Time: 47.037s     Avg. Time: 9.4074s
</pre></details>
