using ShapesLab;
using ShapesLab.Interfaces;

namespace ShapesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCircle_GetArea()
        {
            //arrange
            double R = 10;
            IShape circle = new Circle(R);

            //act
            var a = circle.GetArea();
            double factArea = Math.PI * R * R;

            //assert
            Assert.IsTrue(a == factArea);
        }

        [TestMethod]
        public void CheckCircle_HasBigRadius_TryGetArea()
        {
            //arrange
            double R = double.MaxValue;
            IShape circle = new Circle(R);

            //act
            bool hasException = false;
            try
            {
                var result = circle.GetArea();
            }
            catch
            {
                hasException = true;
            }

            //assert
            Assert.IsTrue(hasException);
        }

        [TestMethod]
        public void CheckTriangle_CorrectSides()
        {
            //arrange
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
                
            IShape triangle = new Triangle(side1,side2,side3);
            Triangle triangle1 = new Triangle(side1, side2, side3);

            //act
            var a = triangle.GetArea();
            var a1 = triangle1.GetArea();

            //assert
            Assert.IsTrue(a == 3*4/2 );
            Assert.IsTrue(a1 == a);
        }

        [TestMethod]
        public void CheckTriangle_HasNegativeSide()
        {
            //arrange
            double side1 = -10;
            double side2 = 10;
            double side3 = 10;

            IShape triangle = new Triangle(side1, side2, side3);

            //act
            bool hasException = false;
            
            try
            {
                triangle.GetArea();
            }
            catch
            {
                hasException=true;
            }

            //assert
            Assert.IsTrue(hasException);

        }

        [TestMethod]
        public void CheckTriangle_HasBigSide()
        {
            //arrange
            double side1 = 100;
            double side2 = 10;
            double side3 = 10;

            IShape triangle = new Triangle(side1, side2, side3);

            //act
            bool hasException = false;

            try
            {
                triangle.GetArea();
            }
            catch
            {
                hasException = true;
            }

            //assert
            Assert.IsTrue(hasException);


        }

        [TestMethod]
        public void CheckTriangle_HasBigSide_TryGetArea()
        {
            //arrange
            double side1 = 100;
            double side2 = 10;
            double side3 = 10;

            IShape triangle = new Triangle(side1, side2, side3);
            Triangle triangle1 = new Triangle(side1, side2, side3);

            //act
            var result = IShape.TryGetArea(triangle, out double area);
            var result1 = IShape.TryGetArea(triangle1, out double area2);

            //assert
            Assert.IsFalse(result);
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckTriangle_CorrectSides_TryGetArea()
        {
            //arrange
            double side1 = 10;
            double side2 = 10;
            double side3 = 10;

            IShape triangle = new Triangle(side1, side2, side3);

            //act
            var result = IShape.TryGetArea(triangle, out double area);
            double p = (side1 + side2 + side3)/2;
            double areaFact = Math.Sqrt(p * (p-side1) * (p-side2) * (p-side3));

            //assert
            Assert.IsTrue(result);
            Assert.IsTrue(area == areaFact);
            
        }

        [TestMethod]
        public void CheckTriangle_IsRight()
        {
            //arrange
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;

            Triangle triangle = new Triangle(side1, side2, side3);

            //act
            var result = triangle.IsRight();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckTriangle_IsNotRight()
        {
            //arrange
            double side1 = 10;
            double side2 = 10;
            double side3 = 10;

            Triangle triangle = new Triangle(side1, side2, side3);

            //act
            var result = triangle.IsRight();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckTriangle_IsRight_BigSide()
        {
            //arrange
            double side1 = double.MaxValue;
            double side2 = double.MaxValue;
            double side3 = 10;

            Triangle triangle = new Triangle(side1, side2, side3);

            //act
            bool hasException = false;
            try
            {
                var result = triangle.IsRight();
            }
            catch
            {
                hasException = true;
            }

            //assert
            Assert.IsTrue(hasException);
        }

        [TestMethod]
        public void CheckNewShape()
        {
            //arrange
            TestShapeRectangle rec1 = new TestShapeRectangle() { Height=2, Width=3};
            IShape rec2 = new TestShapeRectangle() { Height = 2, Width = 3 };

            //act
            var area1 = rec1.GetArea();
            var area2 = rec2.GetArea();
            var fact = 2 * 3;

            //assert
            Assert.IsTrue(area1 == fact);
            Assert.IsTrue(area2 == fact);
        }

        class TestShapeRectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double GetArea()
            {
                return Width*Height;
            }
        }
    }
}