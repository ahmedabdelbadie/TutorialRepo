using cSharpDataStructure.DataStructure;
using OpenHashTable;
using System.Collections;

public static class Program
{
   
    static void Main(string[] args)
    {

        Console.WriteLine("Please enter the string:");
        Console.Write("Input String -> ");
        string input = Console.ReadLine();

        /*Console.WriteLine("Enter Path: ");
        string filePath = @"" + Console.ReadLine();
        FileInfo file = new FileInfo(filePath);
        string input = File.ReadAllText(filePath);
        */

        HuffmanTree huffmanTree = new HuffmanTree(input);
        // Encode
        BitArray encoded = huffmanTree.Encode(input);

        Console.Write("Encoded: ");
        foreach (bool bit in encoded)
        {
            Console.Write((bit ? 1 : 0) + "");
        }
        Console.WriteLine();

        // Decode
        string decoded = huffmanTree.Decode(encoded);

        Console.WriteLine("Decoded: " + decoded);

        Console.ReadLine();
        
        Console.ReadKey();


    }
}

