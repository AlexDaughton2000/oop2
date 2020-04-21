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
            IEnumerable<string> Check_Difference = null,
                Check_Difference2 = null;
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
                    Check_Difference2 = File2.Except(File1);

                }
                catch(Exception e)
                {
                    Console.Write($"{e.Message}\n");
                }
            }
            while (Loop);
            Checking_displaying(Check_Difference,Check_Difference2);            
        }
        public static bool NotEmpty(object Check_Diff)
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

        public static void Checking_displaying(IEnumerable<String> file, IEnumerable<string> file2)
        {
            // An if statement to display the message according to the results.
            if (!NotEmpty(file))
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Text file a and b are not different.", Console.ForegroundColor);
            }
            else
            {
                advanced_Checking(file, file2);
            }
        }

        public static void advanced_Checking(IEnumerable<string> file1, IEnumerable<string> file2)
        {
            //using an example of comparing 2a and 2b
            // file1 = You can only push to two types of URL addresses:
            //file2 = You can only push to two types of url addresses:
            //so you've got to write a bit of code that highlights URL in green
            string sentence = "";
            if(NotEmpty(file1))
            {
                //program finds the difference
                //what you've got to do now it find out which line the difference appears on
                // you are banned from reading a file into the program, so if you want access to the original file you'll need to bring it in as an argument in the brackets
                string[] file1List = new string[0],
                    file2List = new string[0];
                foreach(string s in file1)
                {
                    file1List = s.Split();
                }
                foreach(string s in file2)
                {
                    file2List = s.Split();
                }
                Console.Write(">: [Output] ");
                for (int i = 0; i < file1List.Length; i++)
                {
                    //so the first if statement will see if two words are the same
                    if(file1List[i] == file2List[i])
                    {
                        Console.Write($"{file1List[i]} ");
                        sentence += file1List[i];
                    }
                    else
                    {
                        Console.Write($"{file2List[i]} ", Console.ForegroundColor = ConsoleColor.Green);
                        sentence += file2List[i];
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Log(sentence);
        }
        public static void Log(string change)
        {
            File.WriteAllText(@"Log.txt", change);
        }
    }
}
