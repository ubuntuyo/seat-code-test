using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_code_test
{
    public class Robot
    {
        private int x, y;
        private string pointingTo;

        public Robot(int pointX, int pointY, string orientation)
        {
            x = pointX;
            y = pointY;
            pointingTo = orientation.ToUpper();
        }

        public void Move(int rowSize, int colSize)
        {
            if(pointingTo.Equals("O"))
            {
                if (y > 0)
                    y--;                
            }
            else if (pointingTo.Equals("E"))
            {
                if (y < colSize - 1)
                    y++;
            }
            else if (pointingTo.Equals("S"))
            {
                if (x > 0)
                    x--;
            }
            else if (pointingTo.Equals("N"))
            {
                if (x < rowSize - 1)
                    x++;
            }


        }

        public void Rotate(string rotateTo) // Left or Right
        {
            if (rotateTo.Equals("L"))
            {
                if (pointingTo.Equals("N"))
                    pointingTo = "O";
                else if(pointingTo.Equals("S"))
                    pointingTo = "E";
                else if (pointingTo.Equals("E"))
                    pointingTo = "N";
                else if (pointingTo.Equals("O"))
                    pointingTo = "S";
            }
            else if (rotateTo.Equals("R"))
            {
                if (pointingTo.Equals("N"))
                    pointingTo = "E";
                else if (pointingTo.Equals("S"))
                    pointingTo = "O";
                else if (pointingTo.Equals("E"))
                    pointingTo = "S";
                else if (pointingTo.Equals("O"))
                    pointingTo = "N";
            }

        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public string GetPointingTo()
        {
            return pointingTo;
        }


    }
}
