using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formatting_Homework;

class Program
{
    static void Main(string[] args)
    {
        while (EventCommands.ExecuteNextCommand()) 
        { 
        }
        Console.WriteLine(Messages.output);
    }
}