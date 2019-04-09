using System;
using Hangfire;

namespace HangfireSync.ConsoleApp
{
    class Program
    {
        private static int counter = 0;

        static void Main(string[] args)
        {
            const string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Emprevo;Integrated Security=True";

            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);
            GlobalJobFilters.Filters.Add(new SkipWhenPreviousJobIsRunningAttribute());

            var server = new BackgroundJobServer();
            RecurringJob.AddOrUpdate(() => RunMyTask(), Cron.Minutely);

            Console.WriteLine("Press enter key to stop.");
            Console.ReadLine();

            server.Dispose();
        }

        public static void RunMyTask()
        {
            MyTaskService.RunTask(++counter);
        }
    }
}
