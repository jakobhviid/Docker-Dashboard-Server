using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
namespace DashboardServer {
    public class Program {
        static async Task Main(string[] args) {
            
            CancellationTokenSource cts = new CancellationTokenSource();

            //Handle sigterm signals
            AppDomain.CurrentDomain.ProcessExit += (_, e) => {
                cts.Cancel();
                Environment.ExitCode = 0;
                return;
            };

            //Handle sigint signals
            Console.CancelKeyPress += (_, e) => {
                // when CTRL C is pressed, terminate the process. Otherwise keep it going
                e.Cancel = true;
                cts.Cancel();
                Environment.ExitCode = 0;
                return;
            };

            var processesToStart = (Environment.GetEnvironmentVariable("DASHBOARDS_PROCESSES_TO_START") ?? "overviewdata,statsdata,commandserver").Split(",");

            IList<Task> tasks = new List<Task>();

            if (processesToStart.Contains("commandserver")) {
                var commandServerTask = new Task(() => CommandServer.CommandServer.Start(cts));
                tasks.Add(commandServerTask);
                commandServerTask.Start();
                Console.WriteLine("Started Command Server");
            }

            var updatersTask = new Task(() => Updaters.DockerUpdater.Start());
            tasks.Add(updatersTask);
            updatersTask.Start();
            Console.WriteLine("Started Docker Updaters");
            await Task.WhenAll(tasks); // Don't exit program
        }

    }
}
