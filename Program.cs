using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FileToImage.Core;
using static FileToImage.Ui.ColorConsoleWrite;

namespace FileToImage
{
    class Program
    {
        private static Mode mode;

        static void Main(string[] args)
        {
            // TODO:
            /*
             * Ask used to Create or read a image.
             * If create, create a ImageCreator instance.
             * If read, create a ImageReader instance.
             *
             * Ask the user for a input file.
             * If create, it can be any file.
             * If read, it has to be a png (Or jpg?)
             *
             * Pass that file converted to a byte array to the Begin(bytearray) method of the selected class.
             *
             * Rest is handled by the classes themselves.
             */

            mode = Mode.Read;
            //
            // FileSelector fileSelector = new FileSelector(".png");
            // string filePath = fileSelector.GetFileFromUser();
            //
            // Console.WriteLine($"Selected file: {filePath}");

            ModeSelect();

            if (mode == Mode.Read)
            {
                ImageReader imageReader = new ImageReader();
            }
            else if (mode == Mode.Write)
            {
                ImageWriter imageWriter = new ImageWriter();
            }
        }



        static void ModeSelect()
        {
            Console.WriteLine("Please select mode. Cycle options with TAB.");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Tab:
                            CycleMode();
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Console.WriteLine($"{mode} selected!");
                            return;
                    }
                }
            }
        }

        static void CycleMode()
        {
            // TODO: Ugly solution, make nicer!

            Console.Clear();
            if (mode == Mode.Read)
            {
                mode = Mode.Write;
                ColorWrite(mode.ToString(), ConsoleColor.Green);
            }
            else
            {
                mode = Mode.Read;
                ColorWrite(mode.ToString(), ConsoleColor.Red);
            }
        }
    }

    public enum Mode
    {
        Write,
        Read
    }
}
