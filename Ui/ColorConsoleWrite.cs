using System;
using System.Drawing;

namespace FileToImage.Ui
{
   public struct ColorConsoleWrite
   {
       public static void ColorWrite(string textToPrint, ConsoleColor color)
       {
           Console.ForegroundColor = color;
           Console.Write(textToPrint);
           Console.ForegroundColor = ConsoleColor.White;
       }
       
       public static void ColorWriteLine(string textToPrint, ConsoleColor color)
       {
           Console.ForegroundColor = color;
           Console.WriteLine(textToPrint);
           Console.ForegroundColor = ConsoleColor.White;
       }
   } 
}
