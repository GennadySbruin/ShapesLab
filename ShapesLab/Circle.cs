using ShapesLab.Exceptions;
using ShapesLab.Interfaces;

namespace ShapesLab
{

    /// <summary>
    /// Circle shape
    /// </summary>
    public class Circle (double r) : IShape
    {
        /// <summary>
        /// Circle radius
        /// </summary>
        public double R = r;


        /// <summary>
        /// <para>
        /// Calculate circle area.
        /// To avoid exceptions use the safe method: <code>IShape.TryGetArea()</code> 
        /// </para>
        /// </summary>
        /// <exception cref="ShapeWrongSizeException"></exception>
        /// <exception cref="NotFiniteNumberException"></exception>
        public double GetArea()
        {
            double result =  Math.PI * R * R;

            if (R == double.PositiveInfinity)
                throw new ShapeWrongSizeException("Wrong circle size: circle radius is more then double.MaxValue");
            if (result == double.PositiveInfinity)
                throw new NotFiniteNumberException("Wrong circle size: result area is more then double.MaxValue");
            return result;
        }


    }
}
