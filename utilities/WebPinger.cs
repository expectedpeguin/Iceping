using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iceping.Dependencies
{
    internal class WebPinger
    {
        internal static int sreq = 0;
        internal static int creq = 0;

        internal static void PerformIceRequest(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: Icerequest.exe <type> <url> <method> <rps> <cps>");
                Console.WriteLine("");
                Console.WriteLine("<type>: Specify the method, \"HTTP\" could be for Web HTTP/HTTPS requests and the \"TCP\" for TCP connections.");
                Console.WriteLine("<url>: The URL you want to target for your wicked request.");
                Console.WriteLine("<method>: The HTTP method to use (e.g., GET, POST, DELETE).");
                Console.WriteLine("<rps>: Number of requests per second (default: 1).");
                Console.WriteLine("<cps>: Number of connections per second (default: 1).");
                return;
            }

            string url = args[1];
            string method = args[2].ToUpper();
            int rps = int.Parse(args[3]);
            int cps = int.Parse(args[4]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.Timeout = TimeSpan.FromSeconds(5);
                var consoleLock = new object();

                var IceTimer = new Timer(async state =>
                {
                    try
                    {
                        for (int i = 0; i < rps; i++)
                        {
                            var IceTask = MakeIceRequest(client, method);
                            var response = await IceTask;

                            if (response.IsSuccessStatusCode)
                            {
                                sreq++;
                                lock (consoleLock)
                                {
                                    ColorConsole.WriteEmbeddedColorLine($"Ice request [cyan]{method}[/cyan] to [blue]{url}[/blue] - Status: [green]{response.StatusCode}[/green]");
                                }
                            }
                            else
                            {
                                creq++;
                                lock (consoleLock)
                                {
                                    ColorConsole.WriteEmbeddedColorLine($"Ice request [cyan]{method}[/cyan] to [blue]{url}[/blue] - Status: [yellow]{response.StatusCode}[/yellow]");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        creq++;
                        lock (consoleLock)
                        {
                            ColorConsole.WriteEmbeddedColorLine("Ice request timed out!");
                        }
                    }
                }, null, 10, 1000 / cps);

                Console.WriteLine("Performing Ice requests...\n");
                Console.CancelKeyPress += delegate
                {
                    IceTimer.Dispose();
                    GetIcePercentages(url);
                    return;
                };

                while (true)
                {
                }
            }
        }

        internal static async Task<HttpResponseMessage> MakeIceRequest(HttpClient client, string method)
        {
            switch (method)
            {
                case "GET":
                    return await client.GetAsync("");
                case "POST":
                    return await client.PostAsync("", null);
                case "PUT":
                    return await client.PutAsync("", null);
                case "DELETE":
                    return await client.DeleteAsync("");
                case "HEAD":
                    return await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, ""));
                case "PATCH":
                    return await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), ""));
                default:
                    throw new NotSupportedException("Ice method not supported. Choose a different Ice method.\n");
            }
        }

        internal static void GetIcePercentages(string url)
        {
            var consoleLock = new object();

            lock (consoleLock)
            {
                Console.WriteLine("");
                ColorConsole.WriteEmbeddedColorLine($"Ice request statistics for [green]{url}[/green]:\n    Requests: Sent = [green]{sreq}[/green], Failed = [red]{creq}[/red]\n");
            }
            Console.ResetColor();
        }
    }
}
