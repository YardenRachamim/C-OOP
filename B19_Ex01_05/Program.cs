using System;
using System.Linq;
using System.Text;

namespace B19_Ex01_05
{
    class Program
    {
        public static void Main()
        {
            int positiveIntegerInput = getPositiveIntegerFromUser();
            char smallestDigit = getSmallestDigitFromPositiveInteger(positiveIntegerInput);
            char biggestDigit = getBiggestDigitFromPositiveInteger(positiveIntegerInput);
            int numberOfDigitsDividedByThree = countNumberOfDigitsDividedByThreeFromPositiveInteger(positiveIntegerInput);
            int numberOfDigitsBiggerThenUnity = countNumberOfDigitsBiggerThenUnity(positiveIntegerInput);

            printPositiveIntegerStatistics(smallestDigit, biggestDigit, numberOfDigitsDividedByThree, numberOfDigitsBiggerThenUnity);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

        }

        private static bool isInputPositiveInteger(string i_UserInput, int i_LegalDigitsNumber, out int io_PositiveIntegerInput)
        {
            bool isInputLengthLegal = i_UserInput.Length == i_LegalDigitsNumber;
            bool isInputInteger = int.TryParse(i_UserInput, out io_PositiveIntegerInput);
            bool isInputPositive = io_PositiveIntegerInput > 0;

            return isInputLengthLegal && isInputInteger && isInputPositive;
        }

        private static int getPositiveIntegerFromUser()
        {
            const int k_numberOfDigits = 8;
            int positiveIntegerInput = -1;

            Console.WriteLine("Please insert an {0} digit positive integer (and then press Enter)", k_numberOfDigits);
            string userInput = Console.ReadLine();

            while(!isInputPositiveInteger(userInput, k_numberOfDigits, out positiveIntegerInput))
            {
                Console.WriteLine(string.Format("'{0}' is not a valid input Please insert an {1} digit positive integer",
                    userInput, k_numberOfDigits));
                userInput = Console.ReadLine();
            }

            return positiveIntegerInput;
        }

        private static char getSmallestDigitFromPositiveInteger(int i_PositiveInteger)
        {
            char[] digits = getDigitsFromInteger(i_PositiveInteger);
            char smallestDigit = digits.Min();

            return smallestDigit;
        }

        private static char getBiggestDigitFromPositiveInteger(int i_PositiveInteger)
        {
            char[] digits = getDigitsFromInteger(i_PositiveInteger);
            char biggestDigit = digits.Max();

            return biggestDigit;
        }

        private static int countNumberOfDigitsDividedByThreeFromPositiveInteger(int i_PositiveInteger)
        {
            char[] digits = getDigitsFromInteger(i_PositiveInteger);
            int digitDividedByThreeCounter = 0;

            foreach(char digit in digits)
            {
                int digitAsInteger = int.Parse(digit.ToString());

                if(digitAsInteger % 3 == 0)
                {
                    digitDividedByThreeCounter++;
                }
            }

            return digitDividedByThreeCounter;
        }

        private static int countNumberOfDigitsBiggerThenUnity(int i_PositiveInteger)
        {
            int integerBase = 10;
            int unityDigit = i_PositiveInteger % integerBase;
            int digitBiggerThenUnityCounter = 0;

            i_PositiveInteger /= integerBase;
            while (i_PositiveInteger != 0)
            {
                if(i_PositiveInteger % 10 > unityDigit)
                {
                    digitBiggerThenUnityCounter++;
                }

                i_PositiveInteger /= integerBase;
            }

            return digitBiggerThenUnityCounter;
        }
        
        private static void printPositiveIntegerStatistics(char i_SmallestDigit, char i_BiggestDigit,
            int i_NumberOfDigitsDividedByThree, int i_NumberOfDigitsBiggerThenUnity)
        {
            StringBuilder statisticsToPrint = new StringBuilder();

            statisticsToPrint.AppendLine(string.Format("Integer smallest digit is: {0}", i_SmallestDigit));
            statisticsToPrint.AppendLine(string.Format("Integer biggest digit is: {0}", i_BiggestDigit));
            statisticsToPrint.AppendLine(string.Format("Integer number of digits devided by three is: {0}", 
                i_NumberOfDigitsDividedByThree));
            statisticsToPrint.AppendLine(string.Format("Integer number of digits bigger then unity digit is: {0}",
                i_NumberOfDigitsBiggerThenUnity));

            Console.WriteLine(statisticsToPrint.ToString());
        }

        private static char[] getDigitsFromInteger(int i_Integer)
        {
            string positiveIntegerString = i_Integer.ToString();
            char[] digits = positiveIntegerString.ToCharArray();

            return digits;
        }
    }
}
