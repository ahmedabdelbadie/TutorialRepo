using cSharpDataStructure.DataStructure;
using OpenHashTable;
using System.Collections;

public static class Program
{
   
    static void Main(string[] args)
    {
        /* this Code to run the huffman tree and get the input from file or console*/
        /*
        Console.WriteLine("Please enter the string:");
        Console.Write("Input String -> ");
        string input = Console.ReadLine();
        
        Console.WriteLine("Enter Path: ");
        string filePath = @"" + Console.ReadLine();
        FileInfo file = new FileInfo(filePath);
        string input = File.ReadAllText(filePath);
        */
        /*
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

        */
        OpenHashTable<int, int> OH = new OpenHashTable<int, int>();

        Console.WriteLine("Executing Open Hash Table");
        Console.WriteLine();

        for (int i = 0; i < 100; i++)
            OH.InsertSorted(i, i);

        OH.Print();
        Console.WriteLine("Print Hash table after removing from 0 to hundred heys devided with 2");
        Console.WriteLine();
        for (int i = 0; i < 100; i += 2)
            OH.Remove(i);

        OH.Print();


        OH.Output();



    }
}

