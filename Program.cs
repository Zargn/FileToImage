using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using FileToImage.Core;

namespace FileToImage
{
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
            string filePath = fileSelector.GetFileFromUser();

            Console.WriteLine($"Selected file: {filePath}");
        }
    }
    
    public enum Mode
    {
        Write,
        Read
    }
}
