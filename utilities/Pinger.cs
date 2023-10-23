using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Threading;

namespace iceping.utilities
{
    internal class Ping
    {
        internal static int sping = 0;
        internal static int rping = 0;
        internal static int fping = 0;
        internal static bool cancellationRequested = false;

        internal static void Pinger(string[] args)
        {

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: iceping.exe TCP <host> <port>");
                Console.WriteLine("");
                Console.WriteLine("<host>: You can use a hostname as example \"example.com\" or an ip address \"0.0.0.0\".");
                Console.WriteLine("<port>: Use any integer between 1 to 65535.");
                return;
            }
            string host = args[1];
            int port = int.Parse(args[2]);
            var stopwatch = new Stopwatch();
            var refhost = "";

            if (Dns.GetHostAddresses(host)[0].ToString() != args[1])
            {
                refhost = $"{args[1]} [[green]{Dns.GetHostAddresses(host)[0]}[/green]]";
            }
            else
            {
                refhost = $"[green]{Dns.GetHostAddresses(host)[0]}[/green]";
            }
            ColorConsole.WriteEmbeddedColorLine($"Pinging {refhost}:");
            Console.CancelKeyPress += delegate
            {
                GetPercentages(args[1]);
                cancellationRequested = true;
                return;
            };
            while (true)
            {

                if (cancellationRequested)
                {
                    GetPercentages(args[1]);
                }
                try
                {

                    var endPoint = new IPEndPoint(Dns.GetHostAddresses(host)[0], port);
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    stopwatch.Start();

                    var result = socket.BeginConnect(endPoint, ConnectCallback, socket);
                    var success = result.AsyncWaitHandle.WaitOne(1000);
                    stopwatch.Stop();

                    if (success)
                    {
                        ColorConsole.WriteEmbeddedColorLine("Connected to [green]" + Dns.GetHostAddresses(host)[0] + "[/green]: time=[green]" + stopwatch.ElapsedMilliseconds + "ms[/green] protocol=[green]TCP[/green] port=[green]" + port + "[/green]");
                        stopwatch.Reset();
                        rping++;
                        sping++;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        ColorConsole.WriteEmbeddedColorLine("[red]Connection timed out[/red]");
                        sping++;
                        fping++;
                    }
                }
                catch
                {
                    ColorConsole.WriteEmbeddedColorLine("[red]Connection timed out[/red]");
                    stopwatch.Stop();
                    stopwatch.Reset();
                    sping++;
                    fping++;
                }
            };

        }
        internal static void GetPercentages(string ip)
        {
            Console.WriteLine("");
            ColorConsole.WriteEmbeddedColorLine($"Ping statistics for [green]{ip}[/green]:\r\n    Packets: Sent = [green]{sping}[/green], Received = [green]{rping}[/green], Lost = [red]{fping}[/red] ([red]{Convert.ToInt32(Math.Floor(fping * 100.0 / sping))}%[/red] loss)");

        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                var socket = (Socket)ar.AsyncState;
                socket.EndConnect(ar);
                socket.Close();
            }
            catch { }
        }

    }
}
