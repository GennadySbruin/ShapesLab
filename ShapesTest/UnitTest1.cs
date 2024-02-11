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
        public void CheckTriangle_GetArea()
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