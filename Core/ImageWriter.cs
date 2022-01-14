using System;
using System.IO;
using System.Net.Mime;
using FileToImage.Ui;

namespace FileToImage.Core
{
    public class ImageWriter
    {
        public ImageWriter()
        {
            // TODO:
            // Ask the user for any file. (Or possibly directory in the future?)
            // Split the file into equal parts for the workers. (Later optimisations could allow smaller chunks that are handed out when a worker is done with previous piece.)
            // Start the workers and wait for them all to complete and return their data.
            // Compile the final data into one image.
            // Ask the user to select a directory to save the file. (File name will be a random string. The name for the origin file will be encoded with the data.)

            const string fileExtensionTarget = "";

            Console.WriteLine("Please select a file!");
            
            FileSelector fileSelector = new FileSelector(fileExtensionTarget, FilterMode.Everything);
            string pathToFile = fileSelector.GetFileFromUser();
            if (pathToFile == "")
                return;

            Console.WriteLine("Selected file:");
            Console.WriteLine(pathToFile);

            byte[] fileBytes = File.ReadAllBytes(pathToFile);
            
            Console.WriteLine(fileBytes.Length);
            
            // TODO:
            // Set up a method that returns a chunk of data from the file, and the index of that chunk.
            // Set up a method that takes a chunk of processed data from workers and puts it in the correct part of the image
            // based on the index of the preprocessed chunk.
            
            // Get the amount of cpu's available.
            // Start that amount of workers.
            // The workers requests a chunk if they have nothing to do. If the request returns null then the work is done, and the worker
            // will self destruct.
            // 
        }
    }
}