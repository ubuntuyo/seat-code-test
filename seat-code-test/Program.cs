using System;

namespace seat_code_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SEAT:CODE TEST\n");

            int colSize = 6;
            int rowSize = 7;
            int[,] matrix = new int[rowSize,colSize];
            bool correctFormat = false;
            bool quit = false;
            string[] formatInput = null;

            while (!correctFormat)
            {
                Console.WriteLine("Please insert the coordinate X Y + orientation (N,S,O,E) like this example: 1 2 N\n");

                string input = Console.ReadLine();

                formatInput = input.Split(' ');
                if (formatInput.Length == 3)
                {
                    correctFormat = true;
                }
            }

            int locationX = int.Parse(formatInput.GetValue(0).ToString());
            int locationY = int.Parse(formatInput.GetValue(1).ToString());
            string pointinTo = formatInput.GetValue(2).ToString();

            Robot r = new Robot(locationX,locationY,pointinTo);

            PaintMatrix(rowSize, colSize, locationX, locationY, pointinTo);

            while (!quit)
            {
                Console.WriteLine("Please add rotations L R or movements M, like this example: LMLMLMLMM or MMRMMRMRRM, for quit Q");

                string input = Console.ReadLine();
                input = input.ToUpper();

                if (input.Equals("Q"))
                    quit = true;

                // Copy character by character into array 
                for (int i = 0; i < input.Length; i++)
                {
                    string code = input[i].ToString();

                    if (code.Equals("L") || code.Equals("R"))
                        r.Rotate(code);
                    else if (code.Equals("M"))
                        r.Move(rowSize,colSize);
                }

                PaintMatrix(rowSize, colSize, r.GetX() , r.GetY(), r.GetPointingTo());

            }


        }

        static void PaintMatrix(int rowSize, int colSize, int locationX, int locationY, string pointingTo)
        {
            Console.Write("\n MATRIX:");
            Console.WriteLine("\n");

            Console.WriteLine("Actual position: " + locationX + "," + locationY + " pointing to " + pointingTo+ "\n");

            for (int i = rowSize - 1; i >= 0 ; i--)
            {
                for (int j = 0; j <= colSize -1; j++)
                {
                    if (i == locationX && j == locationY)
                        Console.Write(" " + pointingTo);
                    else
                        Console.Write(" x");
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n");
        }
    }
}
