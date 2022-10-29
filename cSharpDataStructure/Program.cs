using OpenHashTable;

public static class Program
{
    static void Main(string[] args)
    {
        HashTable<int, int> H = new HashTable<int, int>();

        Console.WriteLine("Executing Open Hash Table");
        Console.WriteLine();

        for (int i = 0; i < 100; i++)
            H.Insert(i, i);

        H.Print();

        for (int i = 0; i < 100; i += 2)
            H.Remove(i);

        H.Print();

        Console.ReadKey();
        Console.WriteLine("Test");
    }

   
}

