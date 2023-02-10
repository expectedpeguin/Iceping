using iceping.utilities;
using System;

namespace iceping
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate
            {
                Ping.getPercentages(args[0]);
                return;
            };
            Ping.Pinger(args);
        }
    }
}
