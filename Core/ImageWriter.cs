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
        }
    }
}