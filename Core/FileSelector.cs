using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static FileToImage.Ui.ColorConsoleWrite;

// TODO:
// Make list view appear all the time.
// Add Directory mode.
// Make TAB also cycle the list.
// Allow user to write path as well.

namespace FileToImage.Core
{
    public enum FilterMode
    {
        Everything,
        Extension
    }
    
    public class FileSelector
    {
        private readonly string extensionFilter;
        private FilterMode filterMode;
        private string filePath;
        private int selectedIndex;
        
        
        
        public FileSelector(string typeExtensionFilter, FilterMode filterMode)
        {
            this.filterMode = filterMode;
            extensionFilter = typeExtensionFilter;
        }



        public string GetFileFromUser()
        {
            filePath = Directory.GetCurrentDirectory();
            Console.WriteLine(filePath);

            List<string> filePaths = Directory.GetFileSystemEntries(Path.GetDirectoryName(filePath)).ToList();

            foreach (var VARIABLE in filePaths)
            {
                Console.WriteLine(VARIABLE);
            }
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            filePaths = MoveBackInDirectory(filePaths);
                            break;
                        
                        case ConsoleKey.RightArrow:
                            filePaths = EnterSelection(filePaths);
                            break;
                        
                        case ConsoleKey.UpArrow:
                            filePath = GoUpList(filePaths);
                            break;
                        
                        case ConsoleKey.DownArrow:
                            filePath = GoDownList(filePaths);
                            break;
                        
                        case ConsoleKey.Escape:
                            Console.WriteLine("EXITING");
                            return "";
                        
                        case ConsoleKey.Enter:
                            if (!PathIsDirectory(filePath))
                            {
                                if (PathIsValidSelection(filePath))
                                {
                                    return filePath;
                                }
                            }
                            else
                                Console.WriteLine($"Selection can't proceed because {filePath} is a directory!");
                            break;
                        
                        default:
                            Console.WriteLine("No valid input");
                            break;
                    }

                    ColorWriteLine(filePath, ConsoleColor.Blue);
                }
            }
        }
        
        

        private bool PathIsValidSelection(string filePath)
        {
            if (filterMode == FilterMode.Everything)
            {
                return true;
            }
            
            if (filterMode == FilterMode.Extension)
            {
                if (Path.GetExtension(filePath) == extensionFilter)
                {
                    return true;
                }
                Console.WriteLine($"Selection does not match the file extension: [{extensionFilter}]!");
                return false;
            }

            return false;
        }
        
        
        
        private List<string> MoveBackInDirectory(List<string> filePaths)
        {
            string directoryPath = "";
            string tempPath = filePaths[0];
            for (int i = 0; i < 2; i++)
            {
                directoryPath = Path.GetDirectoryName(tempPath);
                tempPath = directoryPath;
                if (directoryPath == null)
                    return filePaths;
            }
            
            filePaths = Directory.GetFileSystemEntries(directoryPath).ToList();

            for (int index = 0; index < filePaths.Count; index++)
            {
                Console.WriteLine($"list: {filePaths[index]} path: {Path.GetDirectoryName(filePath)}");
                if (filePaths[index] == Path.GetDirectoryName(filePath))
                {
                    selectedIndex = index;
                    filePath = filePaths[index];
                    Console.WriteLine("Success!");
                    break;
                }
                selectedIndex = 0;
            }
            return filePaths;
        }

        
        
        /// <summary>
        /// Enter the selected path. If it is a directory, the focus will now be inside that directory.
        /// </summary>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        private List<string> EnterSelection(List<string> filePaths)
        {
            if (PathIsDirectory(filePaths[selectedIndex]))
            {
                filePaths = Directory.GetFileSystemEntries(filePaths[selectedIndex]).ToList();
                
                // Since we do not know how many files are in the selected folder we need to set the index to 0.
                selectedIndex = 0;

                filePath = filePaths[selectedIndex];
            }
            
            Console.WriteLine("Selected entry");
            return filePaths;
        }

        
        
        private string GoUpList(List<string> filePaths)
        {
            Console.WriteLine("Went up the list");

            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = filePaths.Count - 1;

            return filePaths[selectedIndex];
        }

        
        
        private string GoDownList(List<string> filePaths)
        {
            Console.WriteLine("Went down the list");

            selectedIndex++;
            if (selectedIndex >= filePaths.Count)
                selectedIndex = 0;

            return filePaths[selectedIndex];
        }

        
        
        /// <summary>
        /// Returns if selected path is a directory or not.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool PathIsDirectory(string path)
        {
            FileAttributes pathAttr = File.GetAttributes(path);
            if ((pathAttr & FileAttributes.Directory) == FileAttributes.Directory)
                return true;
            return false;
        }
    }
}