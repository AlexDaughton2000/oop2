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
            //I started by making a simple loops that runs the code below it once. This loop can be changed so that the loop loops forever until the user enters diff

            bool Loop = true;
            IEnumerable<string> Check_Difference = null,
                Check_Difference2 = null;
            do
            {
                try
                {
                    Console.Write(">: [Input] "); //Here I check for the user input, expecting 'diff file1.txt file2.txt' to work 
                    string[] Userinput = Console.ReadLine().Split(),
                    File1 = File.ReadAllLines(Userinput[1]),
                    File2 = File.ReadAllLines(Userinput[2]);

                    if (Userinput[0].ToLower() == "diff")
                    {
                        Loop = false;
                    }
                    else
                    {
                        Console.Write("Diff has not been entered \n");//if diff is not entered I will have an error shown so that I have some exception handling 

                    }
                    Check_Difference = File1.Except(File2); //I then run the check_difference method
                    Check_Difference2 = File2.Except(File1);

                }
                catch(Exception e)//more exception handling to keep the code running smoothly
                {
                    Console.Write($"{e.Message}\n");
                }
            }
            while (Loop);
            Checking_displaying(Check_Difference,Check_Difference2);            
        }
        public static bool NotEmpty(object Check_Diff) //Here I made a method to handle what happens if the files have no differences
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

        public static void Checking_displaying(IEnumerable<String> file, IEnumerable<string> file2) //Next I made the method that would report on whether or not the files were different
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

        public static void advanced_Checking(IEnumerable<string> file1, IEnumerable<string> file2) //This method contains advanced checks as well as the code that highlights the change in green
        {

            string sentence = "";
            if(NotEmpty(file1))
            {
                string[] file1List = new string[0],
                    file2List = new string[0];
                foreach(string s in file1) //I split the files down into individual lines then output them
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
