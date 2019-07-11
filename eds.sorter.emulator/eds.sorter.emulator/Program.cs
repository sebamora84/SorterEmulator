using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleHarness.Run(args, new EmulatorService()).Wait();
        }
    }
}
