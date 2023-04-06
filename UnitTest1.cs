using DrawingApp;
using System.Drawing;

namespace DrawingAppTestProject
{
    public class Tests
    {
        private Graphics graphics;

        [SetUp]
        public void Setup()
        {
            graphics = Graphics.FromImage(new Bitmap(100, 100));
        }

        [TearDown]
        public void TearDown()
        {
            graphics.Dispose();
        }

        /// <summary>
        /// Unit test method written using NUnit framework to test the ParseAndExecuteCommand method's "Rectangle" case.
        /// </summary>

        [Test]
        public void ParseAndExecuteCommand_Rectangle_CorrectlyAddsRectangleShapeToShapesList()
        {
            var parser = new CommandParser(graphics);  // creates a new instance of CommandParser with the given graphics object
            parser.currentX = 25;  // Sets the current x-coordinate of the parser to 25
            parser.currentY = 25;  // Sets the current y-coordinate of the parser to 25
            int expectedWidth = 50;  // Sets the expected width of the rectangle to 50
            int expectedHeight = 75;  // Sets the expected height of the rectangle to 75

            // invokes the ParseAndExecuteCommand method of the parser with a rectangle command and the expected width and height 
            parser.ParseAndExecuteCommand($"rectangle {expectedWidth},{expectedHeight}");

            Assert.That(parser.shapes.Count, Is.EqualTo(1));  //  that the number of shapes in the parser's shapes list is equal to 1
            Assert.IsInstanceOf<RectangleShape>(parser.shapes[0]);  // States that the first shape in the parser's shapes list is an instance of RectangleShape
            var rect = (RectangleShape)parser.shapes[0];  // Asserts a variable "rect" and casts the first shape in the parser's shapes list to a RectangleShape
            Assert.That(rect.x, Is.EqualTo(parser.currentX));  // Asserts that the x-coordinate of the rectangle is equal to the current x-coordinate of the parser
            Assert.That(rect.y, Is.EqualTo(parser.currentY));  // Asserts that the y-coordinate of the rectangle is equal to the current y-coordinate of the parser
            Assert.That(rect.width, Is.EqualTo(expectedWidth));  // Asserts that the width of the rectangle is equal to the expected width
            Assert.That(rect.height, Is.EqualTo(expectedHeight));  // Asserts that the height of the rectangle is equal to the expected height
        }


        [Test]
        public void ParseAndExecuteCommand_Circle_CorrectlyAddsEllipseShapeToShapesList()
        {
            
            var parser = new CommandParser(graphics); // Creates a new instance of the CommandParser class, passing in the graphics object
            parser.currentX = 50; // Set the current X position to 50
            parser.currentY = 50; // Set the current Y position to 50
            int expectedRadius = 25; // Set the expected radius to 25

            // Calls the ParseAndExecuteCommand method on the parser instance, passing in the "circle" command.
            parser.ParseAndExecuteCommand($"circle {expectedRadius}"); 

            Assert.That(parser.shapes.Count, Is.EqualTo(1)); // Assert that the number of shapes in the shapes list is equal to 1
            Assert.IsInstanceOf<CircleShape>(parser.shapes[0]); // Assert that the first shape in the shapes list is an instance of the CircleShape class
            var ellipse = (CircleShape)parser.shapes[0]; // Cast the first shape in the shapes list to a CircleShape object and assign it to the ellipse variable
            Assert.That(ellipse.x, Is.EqualTo(parser.currentX)); // Assert that the x property of the ellipse object is equal to the current X position of the parser instance
            Assert.That(ellipse.y, Is.EqualTo(parser.currentY)); // Assert that the y property of the ellipse object is equal to the current Y position of the parser instance
            Assert.That(ellipse.radius, Is.EqualTo(expectedRadius)); // Assert that the radius property of the ellipse object is equal to the expected radius
        
