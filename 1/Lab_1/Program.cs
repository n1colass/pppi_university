using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            App myApp = new App();
            myApp.Start();
        }
    }
    class App
    {
        private string menuItem;
        private void SelectMenuItem()
        {
            Console.WriteLine("1.Specify the number of words in the text");
            Console.WriteLine("2.Perform mathematical operation");
            Console.Write("Select menu item: ");
            menuItem = Console.ReadLine();
        }
        private void GetVariantMenuItem()
        {
            switch (menuItem)
            {
                case "1":
                    {
                        Console.WriteLine(GetWords());
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine(PlusOperation());
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Choose correct variant!");
                    }
                    break;
            }
            Console.ReadLine();
        }
        private string GetWords()
        {
            Console.Write("Type number of words: ");
            int quantity = Int32.Parse(Console.ReadLine());
            string path = @"C:\Users\atela\source\repos\Lab_1\Lab_1\Lorem.txt";
            StreamReader lorem = new StreamReader(path);
            string[] words = lorem.ReadLine().Split(new char[] { ' ' });
            string result = String.Join(" ", words.Take(quantity));
            return result;
        }
        private int PlusOperation()
        {
            Console.Write("Type 1 number: ");
            int firstNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Type 2 number: ");
            int secondNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Result: ");
            return firstNumber + secondNumber;
        }
        public void Start()
        {
            SelectMenuItem();
            GetVariantMenuItem();
        }
    }
}