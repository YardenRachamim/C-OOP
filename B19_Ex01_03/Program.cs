using System;
using SandClock = B19_Ex01_02.Program;

namespace B19_Ex01_03
{
    class Program
    {
        public static void Main()
        {
            int desiredSandClockHeight = getDesiredSandClockHeight();

            SandClock.PrintSandClockByGivenHeight(desiredSandClockHeight);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        private static int getDesiredSandClockHeight()
        {
            int desiredSandClockHeight = 0;

            Console.WriteLine("Please enter sand clock desired height (and then press Enter)");
            string desiredSandClockHeightAsString = Console.ReadLine();
            bool isInteger = int.TryParse(desiredSandClockHeightAsString, out desiredSandClockHeight);

            while (!isInteger || desiredSandClockHeight <= 0)
            {
                Console.WriteLine("'{0}' input it not valid, try again and please enter positive number only:", 
                    desiredSandClockHeightAsString);
                desiredSandClockHeightAsString = Console.ReadLine();
                isInteger = int.TryParse(desiredSandClockHeightAsString, out desiredSandClockHeight);
            }

            return desiredSandClockHeight;
        }
    }
}
