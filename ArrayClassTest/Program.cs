using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_Constructor();
            Test_Set_Get();
            Test_IsFull_And_IsEmpty_Method();
            Test_Append();
            Test_InsertAt_And_RemoveAt();
            End_Of_Test();
            Console.ReadLine();
            Console.WriteLine();
        }

        static void Test_Constructor()
        {
            //This test will go over both constructors
            ArrayInt defaultSize = new ArrayInt(); //creating ArrayInt object
            Console.WriteLine("----------------------TESTING CONSTRUCTORS---------------------- \n");
            Console.WriteLine("Testing default constructor, expecting an empty array of 10: \n");
            Console.WriteLine("\t" + defaultSize.Size + "\n");
            ArrayInt defineSize = new ArrayInt(15); //creating ArrayInt object
            Console.WriteLine("Testing user-defined constructor, expecting an empty array of 15: \n");
            Console.WriteLine("\t" + defineSize.Size + "\n");
            Console.Write("\n");
        }

        static void Test_Set_Get()
        {
            //This test will go over the setters and getters with [] AND the getters and setters of the size property
            ArrayInt defaultSize = new ArrayInt(); //creating ArrayInt object with empty elements
            //Testing the getters and setters for the this[] array index property
            Console.WriteLine("----------------------TESTING SETTINGS VALUES WITH [] AND READING THEM BACK---------------------- \n");
            defaultSize[3] = 7;
            Console.WriteLine("Setting index value 3 and getting it, expecting 7: \n");
            Console.WriteLine("\t" + defaultSize[3] + "\n");

            //lower bounds error testing
            Console.WriteLine("Testing invalid set index of -1, expecting error: \n");
            try
            {
                defaultSize[-1] = 7;
                Console.WriteLine("\t value at index -1 was successfully set, index within range \n");
            }
            catch
            {
                Console.WriteLine("\t attempting to set a value at index -1 resulted in an error, index out of range \n");
            }

            //Upper bounds error testing
            Console.WriteLine("Testing invalid set index of 15, expecting error: \n");
            try
            {
                defaultSize[15] = 7;
                Console.WriteLine("\t value at index 15 was successfully set, index within range \n");
            }
            catch
            {
                Console.WriteLine("\t attempting to set a value at index 15 resulted in an error, index out of range \n");
            }
            Console.Write("\n");

            //Now testing the getters and setters for the size proeprty
            Console.WriteLine("----------------------TESTING GET AND SET SIZE PROPERTY, USING FOR LOOP TO FILL ARRAY---------------------- \n");
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values
            }
            Console.WriteLine("Default array object filled with integers from 0 to: " + (defaultSize.Size - 1) + " expecting array with 10 elements: \n");
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
            defaultSize.Size = 15;
            Console.WriteLine("Now setting the same array to 15 and filling with integers from 0 to: " + (defaultSize.Size - 1) + ", expecting array with 15 elements: \n");
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values
            }
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
            Console.Write("\n");
        }

        static void Test_IsFull_And_IsEmpty_Method()
        {
            //This test will go over the IsFull and IsEmpty methods, testing the various coditions that change the return value
            ArrayInt defaultSize = new ArrayInt(); //creating ArrayInt object with empty elements\
            Console.WriteLine("----------------------TESTING IsFull() METHOD, USING FOR LOOP TO FILL ARRAY---------------------- \n");
            Console.Write("\n");
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values
            }
            Console.WriteLine("Testing array filled with integers from 0 to: " + (defaultSize.Size - 1) + ", expecting IsFull to equal true: \n");
            Console.WriteLine("\t" + defaultSize.IsFull() + "\n");
            Console.WriteLine("Reinitialize same array with 10 elements, expecting IsFull() to equal false: \n");
            defaultSize = new ArrayInt();
            Console.WriteLine("\t" + defaultSize.IsFull() + "\n");
            Console.Write("\n");
            Console.WriteLine("----------------------TESTING IsEmpty() METHOD---------------------- \n");
            Console.WriteLine("Now testing IsEmpty method, previous array is no loger filled, expecting IsEmpty() to equal true: \n");
            Console.WriteLine("\t" + defaultSize.IsEmpty() + "\n");
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values
            }
            Console.WriteLine("Testing array filled with integers from 0 to: " + (defaultSize.Size - 1) + ", expecting IsEmtpty() to equal false: \n");
            Console.WriteLine("\t" + defaultSize.IsEmpty() + "\n");
            Console.Write("\n");
        }

        static void Test_Append()
        {
            //This test will go over the Append method, testing the various coditions that change where a value is appended
            ArrayInt defaultSize = new ArrayInt(); //array of 10 elements
            Console.WriteLine("----------------------TESTING Append() METHOD---------------------- \n");
            Console.Write("\n");
            Console.WriteLine("Append conditions to be tested: if array is empty, if only appends have been used, if setAt[] was used, \n");
            defaultSize.Append(2);
            defaultSize.Append(4);
            defaultSize[3] = 16;
            defaultSize.Append(32);
            Console.WriteLine("Three appends and a setAt have been used, expecting an array with the values: 2, 4, unknown, 16, 32 \n");
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
            Console.WriteLine("Append conditions to be tested: if array is full and append is used, \n");
            defaultSize = new ArrayInt(); //reinitialized array of 10 elements
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values from 0 to Size (10 by default)
            }
            defaultSize.Append(100);
            Console.WriteLine("Appending to full array, expecting an array with " + ((defaultSize.Size * 2) + 1) + " elements and 100 appended in the 11th spot \n");
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
        }

        static void Test_InsertAt_And_RemoveAt()
        {
            //This test will go over the InsertAt and RemoveAt methods, testing the various coditions that change how the array is arranged after a remove or insert
            ArrayInt defaultSize = new ArrayInt(); //array of 10 elements
            Console.WriteLine("----------------------TESTING InsertAt() METHODS---------------------- \n");
            Console.Write("\n");
            Console.WriteLine("InsertAt conditions to be tested: \n \t if array is full, if the insert is at the beginning, if insert is in middle of array, and if the insert is at the end of the array, \n");
            for (int i = 0; i < defaultSize.Size; i++)
            {
                defaultSize[i] = i; //fills array with values from 0 to Size (10 by default)
            }
            defaultSize.InsertAt(0, 100); //insert at beginning of array
            defaultSize.InsertAt(10, 100); //insert at beginning of array
            defaultSize.InsertAt((defaultSize.Size - 1), 100); //insert at end of array
            Console.WriteLine("100 inserted at beginning with full array, middle, expecting an array with these values: 100, ...., 100, ...., 100 \n");
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
            Console.Write("\n");
            Console.WriteLine("----------------------TESTING RemoveAt() METHODS---------------------- \n");
            Console.Write("\n");
            Console.WriteLine("RemoveAt conditions to be tested: \n \t if the insert is at the beginning, if insert is in middle of array, and if the insert is at the end of the array, \n");
            defaultSize.RemoveAt(0); //insert at beginning of array
            defaultSize.RemoveAt(9); //insert at beginning of array
            defaultSize.RemoveAt((defaultSize.Size - 3)); //insert at end of array
            Console.WriteLine("100 removed from beginning, middle, and end of array, expecting an array WITHOUT these values: 100, ...., 100, ...., 100 \n");
            Console.WriteLine("\t" + defaultSize.GetDisplayText(" , ") + "\n");
        }

        static void End_Of_Test()
        {
            Console.Write("\n");
            Console.WriteLine("-------------------------------END OF TEST :)--------------------------------------");
        }
    }
}
