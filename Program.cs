using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FileToImage.Core;
using FileToImage.Threading;

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
                ReadWorker readWorker = new ReadWorker();
            }
            else if (mode == Mode.Write)
            {
                WriteWorker writeWorker = new WriteWorker();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(mode);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                mode = Mode.Read;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(mode);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public enum Mode
    {
        Write,
        Read
    }
}
