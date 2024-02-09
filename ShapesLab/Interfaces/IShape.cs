using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLab.Interfaces
{
    public interface IShape
    {
        double GetArea();

        /// <summary>
        /// Безопасный метод, на тот случай, если заданные параметры фигуры нарушают геометрические законы и расчет площади будет ошибочным действием
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static bool TryGetArea(IShape shape, out double area)
        {
            try
            {
                area = shape.GetArea();
                return true;
            }
            catch
            {
                area = 0.0;
                return false;
            }
        }
    }

    
}
