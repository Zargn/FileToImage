using System;

namespace FileToImage.Core
{
    public class ImageReader
    {
        public ImageReader()
        {
            // Todo:
            // Ask the user for a png file
            // Split the file into equal parts for the workers. (Later optimisations could allow smaller chunks that are handed out when a worker is done with previous piece.)
            // Start the workers and wait for them all to complete and return their data.
            // Compile the final data into one file.
            // Ask the user to select a directory to save the file.
            Console.WriteLine("Not yet implemented!");
        }
    }
}