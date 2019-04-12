using System;
using System.Linq;
using System.Text;

namespace B19_Ex01_01
{
    class Program
    {
        public static void Main()
        {
            string[] stringInputArr = getValidUserInput();
            int[] decimalValues = convertBinaryStringsToDecimalValues(stringInputArr);
            printDecimalValues(stringInputArr, decimalValues);
            calcAndPrintStatistics(stringInputArr, decimalValues);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static string[] getValidUserInput()
        {
            const int k_NumberOfBinaryNumbers = 4;
            const int k_NumberOfBinaryDigits = 8;
            string[] stringInputArr = new string[k_NumberOfBinaryNumbers];
            int countValidInput = 0;

            Console.WriteLine(string.Format("Please enter {0} binary numbers with {1} digits each. (press enter after each number)",
                k_NumberOfBinaryNumbers, k_NumberOfBinaryDigits));
            while (countValidInput < k_NumberOfBinaryNumbers)
            {
                string binaryInput = Console.ReadLine();
                if(!isValidBinaryString(binaryInput, k_NumberOfBinaryDigits))
                {
                    Console.WriteLine("This value is not legal, please try again");
                    continue;
                }

                stringInputArr[countValidInput] = binaryInput;
                countValidInput++;
            }

            return stringInputArr;
        }

        private static bool isValidBinaryString(string i_Input, int i_NumberOfBinaryDigits)
        {
            bool isValidLength = i_Input.Length == i_NumberOfBinaryDigits;
            bool containsBinaryDigits = isContainsBinaryDigits(i_Input);
            bool isValidInput = isValidLength & containsBinaryDigits;

            return isValidInput;
        }

        private static int[] convertBinaryStringsToDecimalValues(string[] i_BinaryStringsArr)
        {
            int amountOfValuesToConvert = i_BinaryStringsArr.Length;
            int[] convertedDecimalValues = new int[amountOfValuesToConvert];
            
            for(int i = 0; i < amountOfValuesToConvert; i++)
            {
                convertedDecimalValues[i] = convertBinaryStringToDeciamlValue(i_BinaryStringsArr[i]);
            }

            return convertedDecimalValues;
        }

        private static void printDecimalValues(string[] i_StringBinaryArr, int[] i_DecimalValues)
        {
            int numberOfLinesToPrint = i_StringBinaryArr.Length;

            for (int i = 0; i < numberOfLinesToPrint; i++)
            {
                Console.WriteLine(string.Format("Binary = {0}, Decimal = {1}",
                    i_StringBinaryArr[i], i_DecimalValues[i]));
            }
        }
        
        private static void calcAndPrintStatistics(string[] i_StringBinaryArr, int[] i_DecimalValues)
        {
            float averageOfZeros = calcBinaryDigitAverage(i_StringBinaryArr, '0');
            float averageOfOnes = calcBinaryDigitAverage(i_StringBinaryArr, '1');
            int powerOfTwoAppearances = countPowerOfTwoAppearances(i_StringBinaryArr);
            int ascendingOrderAppearances = countAscendingOrderAppearances(i_DecimalValues);
            double averageOfDecimalValues = calcDecimalAverageValues(i_DecimalValues);
            StringBuilder statistics = new StringBuilder();

            statistics.AppendLine(string.Format("Average of zeros: {0}", averageOfZeros));
            statistics.AppendLine(string.Format("Average of ones: {0}", averageOfOnes));
            statistics.AppendLine(string.Format("The number od power of two appearances is: {0}", powerOfTwoAppearances));
            statistics.AppendLine(string.Format("The number of ascending order appearances is {0}", ascendingOrderAppearances));
            statistics.AppendLine(string.Format("The avergae of all input values is: {0}", averageOfDecimalValues));
            Console.WriteLine(statistics.ToString());
        }

        private static int convertBinaryStringToDeciamlValue(string i_BinaryString)
        {
            int convertedDecimal = 0;
            int binaryStringLength = i_BinaryString.Length;

            ReverseString(ref i_BinaryString);
            for (int i = 0; i < binaryStringLength; i++)
            {
                int digit = int.Parse(i_BinaryString[i].ToString());
                convertedDecimal += digit * ((int)Math.Pow(2, i));
            }

            return convertedDecimal;
        }

        public static void ReverseString(ref string io_StringToReverse)
        {
            char[] charsInStringToReverse = io_StringToReverse.ToCharArray();

            Array.Reverse(charsInStringToReverse);

            io_StringToReverse = new string(charsInStringToReverse);
        }

        private static bool isContainsBinaryDigits(string i_Input)
        {
            bool containsOnlyBinaryDigits = true;

            foreach(char digit in i_Input)
            {
                containsOnlyBinaryDigits = digit.Equals('0') || digit.Equals('1');
                if(!containsOnlyBinaryDigits)
                {
                    break;
                }
            }

            return containsOnlyBinaryDigits;
        }

        private static double calcDecimalAverageValues(int[] i_DecimalValues)
        {

            return i_DecimalValues.Average();
        }

        private static int countAscendingOrderAppearances(int[] i_DecimalValues)
        {
            int ascendingOrderAppearancesCounter = 0;

            foreach(int decimalValue in i_DecimalValues)
            {
                if (isDecimalInAscendingOrder(decimalValue))
                {
                    ascendingOrderAppearancesCounter++;
                }
            }

            return ascendingOrderAppearancesCounter;
        }

        private static bool isDecimalInAscendingOrder(int i_DecimalValue)
        {
            bool decimalInAscendingOrder = true;
            string decimalValueAsString = i_DecimalValue.ToString();
            char previousDecimalValueChar = '0';

            foreach(char currentDecimalValueChar in decimalValueAsString)
            {
                decimalInAscendingOrder = previousDecimalValueChar < currentDecimalValueChar;
                previousDecimalValueChar = currentDecimalValueChar;
                if (!decimalInAscendingOrder)
                {
                    break;
                }
            }

            return decimalInAscendingOrder;
        }

        private static int countPowerOfTwoAppearances(string[] i_StringBinaryArr)
        {
            int powerOfTwoCounter = 0;

            foreach(string binaryString in i_StringBinaryArr)
            {
                if (isPowerOfTwo(binaryString))
                {
                    powerOfTwoCounter++;
                }
            }

            return powerOfTwoCounter++;
        }

        private static bool isPowerOfTwo(string i_BinaryString)
        {
            return countOccurrencesOfCharInString(i_BinaryString, '1') == 1;
        }

        private static float calcBinaryDigitAverage(string[] i_StringBinaryArr, char i_DigitTocheck)
        {
            float binaryDigitAverage = 0;
            int occurrencesOfDigit = 0;
            float numberOfBinaries = i_StringBinaryArr.Length;

            foreach (string binaryString in i_StringBinaryArr)
            {
                occurrencesOfDigit += countOccurrencesOfCharInString(binaryString, i_DigitTocheck);
            }

            binaryDigitAverage = occurrencesOfDigit / numberOfBinaries;

            return binaryDigitAverage;
        }

        private static int countOccurrencesOfCharInString(string i_StringToCheck, char i_CharToCount)
        {
            int charCounter = 0;

            foreach(char charToCheck in i_StringToCheck)
            {
                if(i_CharToCount == charToCheck)
                {
                    charCounter++;
                }
            }

            return charCounter;
        }
    }
}
