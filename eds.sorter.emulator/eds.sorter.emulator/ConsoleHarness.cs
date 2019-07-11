using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator
{
    public static class ConsoleHarness
    {
        // Run a service from the console given a service implementation
        public static async Task Run(string[] args, IEmulatorService service)
        {
            WriteToConsole(ConsoleColor.Green, "Starting eds.sorter.emulator");
            bool isRunning = true;

            // simulate starting the windows service
            await service.OnStart(args);

            // let it run as long as Q is not pressed
            while (isRunning)
            {
                WriteToConsole(ConsoleColor.Green, "Press [Q]uit to exit the emulator");
                isRunning = HandleConsoleInput(Console.ReadLine());
            }

            // stop and shutdown
            await service.OnStop();
        }


        // Private input handler for console commands.
        private static bool HandleConsoleInput(string line)
        {
            bool canContinue = true;

            // check input
            if (line != null)
            {
                switch (line.ToUpper())
                {
                    case "Q":
                        canContinue = false;
                        break;

                    default:
                        WriteToConsole(ConsoleColor.Red, "Did not understand that input, try again.");
                        break;
                }
            }

            return canContinue;
        }


        // Helper method to write a message to the console at the given foreground color.
        internal static void WriteToConsole(ConsoleColor foregroundColor, string format,
            params object[] formatArguments)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.WriteLine(format, formatArguments);
            Console.Out.Flush();

            Console.ForegroundColor = originalColor;
        }
    }
}
