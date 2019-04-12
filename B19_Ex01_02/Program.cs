using System;

namespace B19_Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintSandClockByGivenHeight(6);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static void PrintSandClockByGivenHeight(int i_SandClockHeight)
        {
            printSandClockRecursivly(i_SandClockHeight, 0);
        }


        private static void printSandClockRecursivly(int i_CurrentSandClockHeight, int i_NumberOfSpaces)
        {
            string astrixToPrint = new String('*', i_CurrentSandClockHeight);
            string spacesToPrint = new String(' ', i_NumberOfSpaces);

            if (i_CurrentSandClockHeight == 1 || i_CurrentSandClockHeight == 2)
            {
                Console.WriteLine(string.Format("{0}{1}", spacesToPrint, astrixToPrint));
                if(i_CurrentSandClockHeight == 2)
                {
                    Console.WriteLine(string.Format("{0}{1}", spacesToPrint, astrixToPrint));
                }

                return;
            }

            Console.WriteLine(string.Format("{0}{1}", spacesToPrint, astrixToPrint));
            i_NumberOfSpaces++;
            i_CurrentSandClockHeight -= 2;
            printSandClockRecursivly(i_CurrentSandClockHeight, i_NumberOfSpaces);
            Console.WriteLine(string.Format("{0}{1}", spacesToPrint, astrixToPrint));
        }
    }
}
