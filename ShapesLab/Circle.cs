using ShapesLab.Interfaces;

namespace ShapesLab
{

    /// <summary>
    /// Circle shape
    /// </summary>
    public class Circle (double radius) : IShape
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public double Radius = radius;


        /// <summary>
        /// Calculate circle area.
        /// </summary>
        public double GetArea()
        {
            return  Math.PI * Radius * Radius;
        }


    }
}
