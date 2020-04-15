using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace oop2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text_file_1a = File.ReadAllLines(@"GitRepositories_1a.txt");
            string[] text_file_1b = File.ReadAllLines(@"GitRepositories_1b.txt");
            string[] text_file_2a = File.ReadAllLines(@"GitRepositories_2a.txt");
            string[] text_file_2b = File.ReadAllLines(@"GitRepositories_2b.txt");
            string[] text_file_3a = File.ReadAllLines(@"GitRepositories_3a.txt");
            string[] text_file_3b = File.ReadAllLines(@"GitRepositories_3b.txt");

            IEnumerable<string> Check_Difference1 = text_file_1a.Except(text_file_1b);
            IEnumerable<string> Check_Difference2 = text_file_2a.Except(text_file_2b);
            IEnumerable<string> Check_Difference3 = text_file_3a.Except(text_file_3b);

            String[] Userinput = Console.ReadLine().Split();
            String File1 = File.ReadAllLines(@"Userinput [1]").Split();
            String File2 = File.ReadAllLines(@"Userinput [2]").Split();
        }
        public static bool EmptyOrNot(object Check_Diff)
        {
            if (Check_Diff != null)
            {
                if (Check_Diff is IEnumerable<object>)
                {
                    return (Check_Diff as IEnumerable<object>).Any();
                }
            }
            return false;
        }

        public static void Checking_displaying(IEnumerable<String> file)
        {
            // An if statement to display the message according to the results.
            if (EmptyOrNot(file) == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Text file a and b are not different.", Console.ForegroundColor);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Text file a and b are different.", Console.ForegroundColor);
            }
        }

        public static advanced_Checking(string[] text_file_1a, string[] text_file_1b)
        {
            if(EmptyOrNot(file) == false)
            {
                var text_file_1a = File.ReadLines(@"GitRepositories_1a.txt");
                var text_file_1b = File.ReadLines(@"GitRepositories_1b.txt");
                IEnumerable<string> inFirstNotInSecond = text_file_1a.Except(text_file_1b);
                IEnumerable<string> inSecondNotInFirst = text_file_1b.Except(text_file_1a);
            }
        }
    }
}
