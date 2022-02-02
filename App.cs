using System;
using System.Collections.Generic;

namespace STL {
    partial class App 
    {
        int[] arr1;
        int[,] arr2;
        int[][] arr3;
        public void Run() {
            Console.WriteLine("О массивах и коллекциях");
            arr1 = new int[10];
            for(int i = 0; i < 10; i++) {
                arr1[i] = i*i;
            }
            foreach(int x in arr1) {
                Console.WriteLine(x);
            }
            Console.WriteLine($"Всего {arr1.Length} элементов");
            
            arr2 = new int[3, 4];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    arr2[i, j] = 10 * i + j + 11;
                }
            }

            Console.WriteLine("двойной");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------");
            arr3 = new int[3][];
            for(int i = 0; i < 3; i++) 
            {
                arr3[i] = new int[2 + i];
                for(int j = 0; j < 2 + i; j++) {
                    arr3[i][j] = 10 * i + j + 11;
                }
            }
            foreach(var x2 in arr3) 
            {
                foreach(var x in x2) {
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }
        }
    }
}