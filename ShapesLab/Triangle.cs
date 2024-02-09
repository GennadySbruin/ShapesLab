using ShapesLab.Exceptions;
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
        public double Side1 = side1, Side2 = side2, Side3 = side3;

        /// <summary>
        /// <para>
        /// Calculate triangles area.
        /// To avoid exceptions use the safe method: <code>IShape.TryGetArea()</code> 
        /// </para>
        /// </summary>
        /// <exception cref="ShapeWrongSizeException"></exception>
        /// <exception cref="NotFiniteNumberException"></exception>
        public double GetArea()
        {
            //Стороны треугольника будет определять внешний клиент, использующий скомпилированную библиотеку
            //Он может ошибиться в логике и задать не корректные стороны треугольника.
            //В этом случае результат функции будет ошибочный (с точки зрения геометрии) - выдаем исключение
            //Как альтернатива, клиент может использовать функцию IShape.TryGetArea(..)
            //Проверка треугольника не входит в требования, но результат расчета площади в нашей зоне ответственности
            //вопрос реализации проверки стоит предварительно обсудить с постановщиком задачи 
            CheckSides();
            var p = (Side1 + Side2 + Side3) / 2;
            double area = Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            if (area == double.PositiveInfinity)
                throw new NotFiniteNumberException("Wrong triangle sides. The result of calculating the area is infinity");
            else
                return area;
            
        }

        /// <summary>
        /// Check triangle sides
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ShapeWrongSizeException"></exception>
        /// <exception cref="NotFiniteNumberException"></exception>
        public bool CheckSides()
        {
            double minSide = Math.Min(Side1, Math.Min(Side2, Side3));

            //Стороны должны быть больше 0
            if (minSide <= 0)
                throw new ShapeWrongSizeException("Wrong triangle sides. The length of one or more sides is less then zero");

            double maxSide = Math.Max(Side1, Math.Max(Side2, Side3));

            //Большая сторона треугольника не может равняться или превышать сумму 2-х других
            if (maxSide >= ((Side1+Side2+Side3) - maxSide))
                throw new ShapeWrongSizeException("Wrong triangle sides. The longest side of a triangle is more then sum of other sides");

            //Большая сторона треугольника не может превышать максимальное значение типа
            if (maxSide == double.PositiveInfinity)
                throw new NotFiniteNumberException("Wrong triangle sides. The longest side of a triangle is double.PositiveInfinity");

            return true;
        }

        /// <summary>
        /// Checking a triangle for squareness.
        /// </summary>
        /// <returns>
        /// returns true if the triangle is right angled
        /// </returns>
        /// /// <exception cref="ShapeWrongSizeException"></exception>
        /// /// <exception cref="NotFiniteNumberException"></exception>
        public bool IsRight()
        {
            CheckSides();

            //Проверяем стороны на соответствие теореме пифагора
            bool isRight = (Side1 * Side1 == Side2 * Side2 + Side3 * Side3) ||
                (Side2 * Side2 == Side1 * Side1 + Side3 * Side3) || 
                (Side3 * Side3 == Side1 * Side1 + Side2 * Side2);

            if (isRight)
            {
                //Можем столкнуться с большими значеними сторон
                //Результат вычислении квадрата стороны или суммы квадратов двух сторон может вернуть PositiveInfinity
                //Это может дать ложный результат проверки (например PositiveInfinity == PositiveInfinity => isRight = true)
                if (Side1 * Side1 == double.PositiveInfinity)
                    throw new NotFiniteNumberException($"Error: Big square of triangle side for double type ({Side1})");
                if (Side2 * Side2 == double.PositiveInfinity)
                    throw new NotFiniteNumberException($"Error: Big square of triangle side for double type ({Side2})");
                if (Side3 * Side3 == double.PositiveInfinity)
                    throw new NotFiniteNumberException($"Error: Big square of triangle side for double type ({Side3})");
            }

            return isRight;
        }
    }
}
