using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLab.Exceptions
{
    public class ShapeWrongSizeException:Exception
    {
        public ShapeWrongSizeException(string message) : base(message) { }
    }
}
