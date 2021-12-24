using System;
using System.IO;

namespace FileToImage
{
    public class FileSelector
    {
        private string filter;
        
        public FileSelector(string typeFilter)
        {
            filter = typeFilter;
        }

        public void Run()
        {
            string filePath = Directory.GetCurrentDirectory();
            Console.WriteLine(filePath);
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            filePath = MoveBackInDirectory(filePath);
                            break;
                        case ConsoleKey.RightArrow:
                            EnterSelection();
                            break;
                        case ConsoleKey.UpArrow:
                            GoUpList();
                            break;
                        case ConsoleKey.DownArrow:
                            GoDownList();
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("EXITING");
                            return;
                        case ConsoleKey.Enter:
                            Console.WriteLine("Confirmed selection");
                            break;
                        default:
                            Console.WriteLine("No valid input");
                            break;
                    }

                    Console.WriteLine(filePath);
                }
            }
        }
        
        string MoveBackInDirectory(string filePath)
        {
            string result = Path.GetDirectoryName(filePath);
            return result ?? filePath;
        }

        void EnterSelection()
        {
            Console.WriteLine("Selected entry");
            // TODO: Select file/directory
        }

        void GoUpList()
        {
            Console.WriteLine("Went up the list");
            // TODO: Move up in file list
        }

        void GoDownList()
        {
            Console.WriteLine("Went down the list");
            // TODO: Move down in file list
        }   
    }
    
    
    
    class Program
    {
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

            FileSelector fileSelector = new FileSelector(".png");
            fileSelector.Run();
        }
    }
    
    public enum Mode
    {
        Write,
        Read
    }
}
