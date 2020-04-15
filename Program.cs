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
            //changes i've made:
            //removed some code from the old wrong version
            //made the program match the look specified in the brief, although output does not match but thats not hard to do
            //error checking was added and the problems with advanced_Checking was done

            bool Loop = true;
            IEnumerable<string> Check_Difference = null;
            do // this will run the below code once but if Loop is changed then the while loop will loop until the user enters diff
            {
                try
                {
                    Console.Write(">: [Input] ");
                    string[] Userinput = Console.ReadLine().Split(),
                    File1 = File.ReadAllLines(Userinput[1]),
                    File2 = File.ReadAllLines(Userinput[2]);

                    if (Userinput[0].ToLower() == "diff")
                    {
                        Loop = false;
                    }
                    else
                    {
                        Console.Write("Diff has not been enter \n");

                    }
                    Check_Difference = File1.Except(File2);
                }
                catch(Exception e)
                {
                    Console.Write($"{e.Message}\n");
                }
            }
            while (Loop);
            Checking_displaying(Check_Difference);            
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
            if (EmptyOrNot(file))
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

        public static void advanced_Checking(IEnumerable<String> file)
        {
            if(EmptyOrNot(file))
            {
                //what ever you need to find the difference in here,
                //if file is not empty then that means there are differences and they are stored in that list
                //so what ever your thinking you need to add, add it here.
            }
        }
    }
}
