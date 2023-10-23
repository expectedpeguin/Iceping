using iceping.Dependencies;
using iceping.utilities;
using System;

namespace iceping
{
    class Program
    {

        static void Main(string[] args)
        {
            if( args[0] == "TCP" && args.Length < 3)
            {
                Console.WriteLine("Usage: iceping.exe <type> <host> <port> <protocol>");
                Console.WriteLine("");
                Console.WriteLine("<type>: Specify the method, \"HTTP\" could be for Web HTTP/HTTPS requests and the \"TCP\" for TCP connections.");
                Console.WriteLine("<host>: You can use a hostname as example \"example.com\" or an ip address \"0.0.0.0\".");
                Console.WriteLine("<port>: Use any integer between 1 to 65535.");
                return;
            }
            else if (args[0] == "HTTP" && args.Length < 4)
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
            switch (args[0])
            {
                case "HTTP":
                    WebPinger.PerformIceRequest(args);
                    break;
                case "TCP":
                    Ping.Pinger(args);
                    break;
                default:
                    break;
            }
            if (args[0] == "HTTP")
            {
                Console.CancelKeyPress += delegate
                {
                    WebPinger.GetIcePercentages(args[1]);
                    Console.ResetColor();
                    return;
                };
            }
            else if (args[0] == "TCP")
            {
                Console.CancelKeyPress += delegate
                {
                    Ping.GetPercentages(args[1]);
                    Console.ResetColor();
                    return;
                };
            }
        }
    }
}
