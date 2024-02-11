using ShapesLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLab
{
    //C# 12
    /// <summary>
    /// Triangle shape
    /// </summary>
    public class Triangle(double side1, double side2, double side3) : IShape
    {
        public double Side1 = side1;
        public double Side2 = side2;
        public double Side3 = side3;

        /// <summary>
        /// Calculate triangles area.
        /// </summary>
        public double GetArea()
        {
            var p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        /// <summary>
        /// Checking a triangle for squareness.
        /// </summary>
        /// <returns>
        /// returns true if the triangle is right angled
        /// </returns>
        public bool IsRight()
        {
            double SquareSide1 = Side1*Side1;
            double SquareSide2 = Side2*Side2;
            double SquareSide3 = Side3*Side3;
            return (SquareSide1 == SquareSide2 + SquareSide3) ||
                   (SquareSide2 == SquareSide1 + SquareSide3) || 
                   (SquareSide3 == SquareSide1 + SquareSide2);
        }
    }
}
