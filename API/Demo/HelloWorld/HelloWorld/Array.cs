using System;


namespace HelloWorld
{
    class Array
    {
        public void Display()
        {
            Console.WriteLine(" ");
            #region One Dimensional Array
                Console.WriteLine("One Dimensional Array");   

                // Initializing 
                string[] months =
                 {
                "January", "February", "March", "April",
                "May", "June", "July", "August",
                "September", "October", "November", "December"
                };
                // Displaying Elements of array
                foreach (string month in months)
                    {
                        Console.WriteLine(month);
                    }

                Console.WriteLine("");
            #endregion One Dimensional Array

            #region MultiDimensional Array
                Console.WriteLine("MultiDimensional Array");

                // Two-dimensional array
                int[,] twoDArray = new int[3, 4]
                {
                        {1, 2, 3, 4},
                        {5, 6, 7, 8},
                        {9, 10, 11, 12}
                };

                // Display elements in the 2D array
                Console.WriteLine("Elements in the 2D array:");

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        Console.WriteLine("2DArray[{0}][{1}]: " + twoDArray[row, col], row, col);
                    }
                    Console.WriteLine();
                }
            #endregion MultiDimensional Array

            #region Jagged Array
                 Console.WriteLine("Jagged Array");



                //Jagged Array to store number
                int[][] jaggedArray = new int[3][];

                // Initialize the subarrays with different lengths
                jaggedArray[0] = new int[] { 1, 2, 3 };
                jaggedArray[1] = new int[] { 4, 5, 6, 7 };
                jaggedArray[2] = new int[] { 8, 9 };

           
                Console.WriteLine("Elements in the jagged array:");

                //Loop thru and print out elemens of jagged Array
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        Console.Write($"{jaggedArray[i][j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(" ");
            #endregion Jagged Array
        }
    }
}
