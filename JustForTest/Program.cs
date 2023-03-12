// See https://aka.ms/new-console-template for more information
using System;
using System.Text;



/* __________ Problem __________
 *  string 1 => abcdgh
 *  string 2 => eaedfhr 
 *  
*/
string firstString = "abcdhgh";
string SecondString = "bc";

//for (int i = 0; i < firstString.Length; i++)
//{
//    var 
//    for(int j = 0; j<SecondString.Length; j++)
//    {
//        if (firstString[i] == SecondString[j])
//        {

//        }

//    }
//}
//int i = 0;
//List<string> list = new List<string>();
//while(i < firstString.Length)
//{
//    int j = 0;
//    StringBuilder sb = new StringBuilder(); 
//    while (j < SecondString.Length)
//    {
//        if (firstString[i] == SecondString[j])
//        {
//            sb.Append(firstString[i]);
//        }
//        else break;
//        j++;
//    }
//    if(!string.IsNullOrEmpty(sb.ToString())) list.Add(sb.ToString());
//    i++;

//}

int[,] array2D = new int[, ] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

Console.WriteLine(array2D.GetLength(0));
Console.WriteLine(array2D.GetLength(1));
int row = 0; 
int Col = 0;
for (int i = 0; i < array2D.Length  ; i++)
{
    if (Col == array2D.GetLength(1))
    {
        row++;
        Col = 0;
    }
    Console.Write(array2D[row,Col]);
    
    Col++;

}