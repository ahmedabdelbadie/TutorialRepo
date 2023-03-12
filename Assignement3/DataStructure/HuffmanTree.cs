using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDataStructure.DataStructure
{
    public class NodeHuffman :IComparable<NodeHuffman>
    {
        
        public char Character { get; set; }
        public int Frequency { get; set; }
        public NodeHuffman Right { get; set; }
        public NodeHuffman Left { get; set; }

        public int CompareTo(NodeHuffman? node)
        {
            return node.Frequency.CompareTo(this.Frequency);
        }

        public List<bool> CreateCodes(char symbol, List<bool> data)
        {
            // Leaf
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Character))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.CreateCodes(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.CreateCodes(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }
    public class HuffmanTree
    {
        private string _source;
        public HuffmanTree(string source)
        {
           
            _source = source;
            // function to print the character and its
            // frequency in order of its occurrence
            int[] freq = AnalyzeText(_source);
            // Build the Huffman tree
            Build(freq);

        }
        private List<NodeHuffman> nodes = new List<NodeHuffman>();
        public NodeHuffman HT { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(int[] freq)
        {

            // traverse 'str' from left to right
            for (int i = 0; i < _source.Length; i++)
            {
                // if frequency of character str.charAt(i)
                // is not equal to 0
                if (freq[_source[i] - ' '] != 0)
                {

                    // print the character along with its
                    // frequency
                    nodes.Add(new NodeHuffman() { Character = _source[i], Frequency = freq[_source[i] - ' '] });
                    // update frequency of str.charAt(i) to
                    // 0 so that the same character is not
                    // printed again
                    freq[_source[i] - ' '] = 0;
                }
            }

            while (nodes.Count > 1)
            {
                // Using Priority Queue to order the tree
                PriorityQueue<NodeHuffman, int> orderedNodesP = new PriorityQueue<NodeHuffman, int>();
                foreach(var node in nodes)
                {
                    orderedNodesP.Enqueue(node, node.Frequency);
                }
                if (orderedNodesP.Count >= 2)
                {
                    // Take first two items
                    //List<NodeHuffman> taken = orderedNodes.Take(2).ToList<NodeHuffman>();
                    NodeHuffman item1 = orderedNodesP.Dequeue();
                    NodeHuffman item2 = orderedNodesP.Dequeue();
                    List<NodeHuffman> takenp = new List<NodeHuffman> { item1, item2 };  
                    // Create a parent node by combining the frequencies
                    NodeHuffman parent = new NodeHuffman()
                    {
                        Character = '*',
                        Frequency = takenp[0].Frequency + takenp[1].Frequency,
                        Left = takenp[0],
                        Right = takenp[1]
                    };

                    nodes.Remove(takenp[0]);
                    nodes.Remove(takenp[1]);
                    nodes.Add(parent);
                }

                this.HT = nodes.FirstOrDefault();

            }

        }
        // Encode the given text and return astring if 0s and 1s
        public BitArray Encode(string source)
        {
            BitArray bits = null;
            Dictionary<char,List<bool>> D = new Dictionary<char, List<bool>>();
            List<bool> bools = new List<bool>();
            for (int i = 0; i < source.Length; i++)
            {
                // create code of 0s and 1s for each characterby traversing the huffman tree 
                // store code in dictionary
                List<bool> encodedSymbol = this.HT.CreateCodes(source[i], new List<bool>());
                if(!D.ContainsKey(source[i])) D.Add(source[i], encodedSymbol);
            }
            //= new BitArray(D.SelectMany(d => d.Value).ToArray());
            for (int i = 0; i < source.Length; i++)
            {
                bools.AddRange(D[source[i]]);
            }

            bits = new BitArray(bools.ToArray());

            return bits;
        }
        // DEcode the given a string of 0s and 1s  and return text
        public string Decode(BitArray bits)
        {
            NodeHuffman current = this.HT;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Character;
                    current = this.HT;
                }
            }

            return decoded;
        }

        public bool IsLeaf(NodeHuffman node)
        {
            return (node.Left == null && node.Right == null);
        }
        public static int SIZE = 190;
        // function to print the character and its
        // frequency in order of its occurrence
        public int[] AnalyzeText(String str)
        {
            // size of the string 'str'
            int n = str.Length;

            // 'freq[]' implemented as hash table
            int[] freq = new int[SIZE];
            int asciiCode = (int)' ';
            // accumulate frequency of each character
            // in 'str'
            for (int i = 0; i < n; i++)
                freq[str[i] - ' ']++;

            return freq;
        }
    }
}
