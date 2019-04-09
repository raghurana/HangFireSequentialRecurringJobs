using System;
using System.Threading;

namespace HangfireSync.ConsoleApp
{
    public class MyTaskService
    {
        [SkipWhenPreviousJobIsRunning]
        public static void RunTask(int id)
        {
            Console.WriteLine($"Running MyTaskService {id} ...");

            Thread.Sleep(TimeSpan.FromSeconds(65));

            Console.WriteLine($"Run {id} Completed.");
        }
    }
}