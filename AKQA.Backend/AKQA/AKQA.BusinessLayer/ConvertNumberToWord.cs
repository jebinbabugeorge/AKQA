using System;
using System.Text;

namespace AKQA.BusinessLayer
{
    public class ConvertNumberToWord
    {
        /// <summary>
        /// This method converts the salary in to words
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public string GetSalaryInWords(double salary)
        {
            StringBuilder sb = new StringBuilder();

            // Spliting out the decimal part and storing as two integers
            int[] numbers = new int[] { (int)salary, (int)(Math.Round((salary % 1) * 100)) };
            int index = 0;

            bool status = numbers.Length > 1 && numbers[1] > 0;

            foreach (var item in numbers)
            {
                if (item > 0)
                {
                    sb.Append(FindPlace(item));
                }

                if (index == 0)
                {
                    // if no decimal part, do not append 'AND'
                    sb.Append(status ? " DOLLARS AND " : " DOLLARS");
                    index++;
                }
                else if(status)
                {
                    sb.Append(" CENTS");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Recursive function that iterates through the places and returns the string for the number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string FindPlace(int number)
        {
            string word = string.Empty;

            if ((number / 1000000) > 0)
            {
                word += FindPlace(number / 1000000) + " MILLION ";
                number %= 1000000;
            }

            if ((number / 1000000) > 0)
            {
                word += FindPlace(number / 100000) + " HUNDRED ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                word += FindPlace(number / 1000) + " THOUSAND ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                word += FindPlace(number / 100) + " HUNDRED AND ";
                number %= 100;
            }

            if (number < 10)
            {
                word += OnesString(number);
            }
            else
            {
                word += TensString(number);
            }

            return word;
        }

        /// <summary>
        /// Function that return single digit numbers in words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string OnesString(int number)
        {
            string word = string.Empty;

            switch (number)
            {
                case 1:
                    word = "ONE";
                    break;
                case 2:
                    word = "TWO";
                    break;
                case 3:
                    word = "THREE";
                    break;
                case 4:
                    word = "FOUR";
                    break;
                case 5:
                    word = "FIVE";
                    break;
                case 6:
                    word = "SIX";
                    break;
                case 7:
                    word = "SEVEN";
                    break;
                case 8:
                    word = "EIGHT";
                    break;
                case 9:
                    word = "NINE";
                    break;
                default:
                    break;
            }

            return word;
        }

        /// <summary>
        /// Recursive Function that return two digit numbers in words.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string TensString(int number)
        {
            string word = string.Empty;

            switch (number)
            {
                case 10:
                    word = "TEN";
                    break;
                case 11:
                    word = "ELEVEN";
                    break;
                case 12:
                    word = "TWELVE";
                    break;
                case 13:
                    word = "THIRTEEN";
                    break;
                case 14:
                    word = "FOURTEEN";
                    break;
                case 15:
                    word = "FIFTEEN";
                    break;
                case 16:
                    word = "SIXTEEN";
                    break;
                case 17:
                    word = "SEVENTEEN";
                    break;
                case 18:
                    word = "EIGHTEEN";
                    break;
                case 19:
                    word = "NINETEEN";
                    break;
                case 20:
                    word = "TWENTY";
                    break;
                case 30:
                    word = "THIRTY";
                    break;
                case 40:
                    word = "FOURTY";
                    break;
                case 50:
                    word = "FIFTY";
                    break;
                case 60:
                    word = "SIXTY";
                    break;
                case 70:
                    word = "SEVENTY";
                    break;
                case 80:
                    word = "EIGHTY";
                    break;
                case 90:
                    word = "NINETY";
                    break;
                default:
                    if (number > 0)
                    {
                        word = TensString((number / 10) * 10) + "-" + OnesString(number % 10);
                    }
                    break;
            }

            return word;
        }
    }
}
