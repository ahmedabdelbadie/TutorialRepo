using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        class Node
        {
            public string Directory { get; set; }
            public List<string> File { get; set; }
            public Node LeftMostChild { get; set; }
            public Node RightSibling { get; set; }

            public Node(string directory, List<string> file, Node leftMostChild, Node rightSibling) // Create a node with all fields
            {
                Directory = directory;
                File = file;
                LeftMostChild = leftMostChild;
                RightSibling = rightSibling;
            }
            public Node(string directory) // Create a node with only the directory
            {
                Directory = directory;
                File = new List<string>();
                LeftMostChild = null;
                RightSibling = null;
            }
        }
        class FileSystem
        {
            public Node Root;
            int num = 0;
            // Creates a file system with a root directory
            public FileSystem(string start)
            {
                Root = new Node(start);
            }
            // Adds a file at the given address
            // Returns false if the file already exists or the path is undefined; true otherwise
            public bool AddFile(string address)
            {
                Node curr = Navigate(address, Root);

                if (curr.Directory == address) // Double checks and writes file
                {
                    Console.WriteLine("What do you want it to be named?");
                    curr.File.Add(Console.ReadLine());
                    Console.WriteLine("File added at: {0}", curr.Directory);
                    return true;
                }
                else
                {
                    Console.WriteLine("Unable to write file");
                    return false;
                }
            }
            // Removes the file at the given address
            // Returns false if the file is not found or the path is undefined; true otherwise
            public bool RemoveFile(string address)
            {
                // splits the string into every occurence of '/'
                string[] directory = address.Split('/');
                // Remove the current directory item to find the parent directory
                string parent = address.Remove(address.IndexOf(directory[directory.Length - 1]));

                // Finds the name of the file
                string file = directory[directory.Length - 1];

                Node curr = Navigate(parent, Root);
                if (curr.Directory == parent) // Double checks and removes file
                {
                    curr.File.Remove(file);
                    Console.WriteLine("Removed file at {0}", curr.Directory);
                    return true;
                }
                else
                {
                    Console.WriteLine("Unable to remove file");
                    return false;
                }
            }
            // Adds a directory at the given address
            // Returns false if the directory already exists or the path is undefined; true otherwise
            public bool AddDirectory(string address)
            {
                Node curr = Navigate(address, Root);
                if (curr.Directory == address) // Double checks that address is correct
                {
                    if (curr.LeftMostChild == null) // If address has no children, insert there
                    {
                        Console.WriteLine("What do you want it to be named");
                        curr.LeftMostChild = new Node(curr.Directory + Console.ReadLine() + "/");
                    }
                    else // If address has a child, go through all of it's siblings until you reach the end
                    {
                        Node temp = curr.LeftMostChild;
                        while (temp.RightSibling != null)
                        {
                            temp = temp.RightSibling;
                        }
                        Console.WriteLine("What do you want it to be named");
                        temp.RightSibling = new Node(curr.Directory + Console.ReadLine() + "/");
                    }
                    Console.WriteLine("Directory added at: {0}", curr.Directory);
                    return true;
                }
                else
                {
                    Console.WriteLine("Unable to add directory");
                    return false;
                }

            }
            // Removes the directory (and its subdirectories) at the given address
            // Returns false if the directory is not found or the path is undefined; true otherwise
            public bool RemoveDirectory(string address)
            {
                // Splits the string into every occurence of '/'
                string[] directory = address.Split('/');
                // Remove the current directory item to find the parent directory
                string parent = address.Remove(address.IndexOf(directory[directory.Length - 2]));

                Node curr = Navigate(parent, Root);

                if (curr.LeftMostChild != null) // Checks if child is null 
                {
                    if (curr.LeftMostChild.Directory == address) // If removing left most child
                    {
                        curr.LeftMostChild = curr.LeftMostChild.RightSibling;
                        Console.WriteLine("Removed file at: {0}", curr.Directory);
                        return true;
                    }
                    else // If removing a right sibling
                    {
                        curr = curr.LeftMostChild;
                        while (curr.RightSibling.Directory != address)
                        {
                            curr = curr.RightSibling;
                        }
                        curr.RightSibling = curr.RightSibling.RightSibling;
                        Console.WriteLine("Removed file at: {0}", curr.Directory);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Unable to remove dierectory");
                    return false;
                }
            }
            // Returns the number of files in the file system
            public int NumberFiles(Node curr)
            {
                if (curr == null)
                    return num;
                foreach (string s in curr.File)
                    num++;

                NumberFiles(curr.RightSibling);

                NumberFiles(curr.LeftMostChild);

                return num;
            }
            // Prints the directories in a pre-order fashion along with their files
            public void PrintFileSystem(Node curr)
            {
                // Checks if current node is null
                if (curr == null)
                    return;

                Console.WriteLine(curr.Directory);

                // Prints current directories files
                foreach (string s in curr.File)
                {
                    Console.WriteLine(curr.Directory + s);
                }

                // Recurses through left children
                PrintFileSystem(curr.LeftMostChild);

                // Recurses through all right siblings
                PrintFileSystem(curr.RightSibling);
            }
            // Navigates through system to find given address recursively
            public Node Navigate(string address, Node curr)
            {
                if (curr == null)
                    return curr;
                if (address == curr.Directory)
                {
                    return curr;
                }
                else
                {
                    if (curr.RightSibling != null)
                        curr = Navigate(address, curr.RightSibling);

                    if (curr.LeftMostChild != null)
                        curr = Navigate(address, curr.LeftMostChild);
                    return curr;
                }
            }
        }

        static void Main()
        {
            // First you must define the root and then it creates a new file system with that root
            Console.WriteLine("Input root");
            FileSystem Sys = new FileSystem(Console.ReadLine() + "/");
            // Loops forever
            while (true)
            {
                // List of choices, if the input isn't a number, it tells you that it isn't valid, if input is out of range, it tells you it isn't an option
                Console.WriteLine("\nMake a selection:\n1. Add File\n2. Remove File\n3. Add Directory\n4. Remove Directory\n5. Find Number of Files\n6. Print File System\n7. Exit");
                bool parse = Int32.TryParse(Console.ReadLine(), out int choice);
                Console.Clear();
                if (parse)
                {
                    switch (choice)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("At what address do you want to add a file?");
                            Sys.AddFile(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("What is the address of the file you want to delete?");
                            Sys.RemoveFile(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("At what address would you like to add a directory?");
                            Sys.AddDirectory(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("What is the address of the directory you want to delete?");
                            Sys.RemoveDirectory(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine(Sys.NumberFiles(Sys.Root));
                            break;
                        case 6:
                            Sys.PrintFileSystem(Sys.Root);
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Not a valid option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
