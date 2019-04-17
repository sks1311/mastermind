using System;
using System.Text;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get random number (Mentioned 4 digit in document)
            int randomAnswer = GenerateRandomAnswer();

            int retryCount = 9;

            Console.WriteLine("Welcome, Please enter your guess.");

            bool IsValidInputString = int.TryParse(Console.ReadLine(), out int inputNumber);

            //Give 10 chance if invalid input
            while ((!IsValidInputString || inputNumber.ToString().Length != 4) && retryCount > 0)
            {
                Console.WriteLine("Please retry with 4 digit valid number. You have {0} Retry count left", retryCount--);
                IsValidInputString = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            //If valid input
            while (retryCount > 0 && IsValidInputString)
            {
                //exit loop if correct answer
                if (randomAnswer == inputNumber)
                {
                    Console.WriteLine("You are MasterMind. Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                //else compare Digits
                Compare(randomAnswer, inputNumber);

                Console.WriteLine("Please retry with 4 digit valid number. You have {0} Retry count left", retryCount--);

                //take next input
                IsValidInputString = int.TryParse(Console.ReadLine(), out inputNumber);

                //check again for input validation
                while ((!IsValidInputString || inputNumber.ToString().Length != 4) && retryCount > 0)
                {
                    Console.WriteLine("Please retry with 4 digit valid number. You have {0} Retry count left", retryCount--);
                    IsValidInputString = int.TryParse(Console.ReadLine(), out inputNumber);
                }
            }

            //Check in case of last input is correct
            if (randomAnswer == inputNumber)
            {
                Console.WriteLine("You are MasterMind. Press any key to exit");
            }
            else
            {
                Console.WriteLine("You Lost. Press Any Key to exit the program");
            }

            Console.ReadKey();

        }
        /// <summary>
        /// compares two int input, digit by digit
        /// </summary>
        /// <param name="randomAnswer"></param>
        /// <param name="inputNumber"></param>
        private static void Compare(int randomAnswer, int inputNumber)
        {
            string input = inputNumber.ToString();
            string answer = randomAnswer.ToString();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int intNumValue = (int)char.GetNumericValue(input[i]);
                int ansNumVlaue = (int)char.GetNumericValue(answer[i]);

                if (intNumValue == ansNumVlaue)
                {
                    output.Insert(0, "+");
                }
                else if (intNumValue != ansNumVlaue)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        intNumValue = (int)char.GetNumericValue(input[j]);
                        if (intNumValue == ansNumVlaue)
                        {
                            output.Append("-");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(output);
        }

        //returns a random number. (can also use string instead of int)
        private static int GenerateRandomAnswer()
        {
            Random random = new Random();
            return Convert.ToInt32(random.Next(1, 6).ToString() +
                random.Next(1, 6).ToString() +
                random.Next(1, 6).ToString() +
                random.Next(1, 6).ToString());

        }
    }
}
