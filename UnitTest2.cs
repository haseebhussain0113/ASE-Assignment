
        [Test]
        public void ParseAndExecuteCommand_DrawTo_CorrectlyAddsLineShapeToShapesList()
        {

            var parser = new CommandParser(graphics);  // create a new instance of CommandParser with graphics object
            parser.currentX = 25; // set the current X-coordinate of the parser
            parser.currentY = 50; // set the current Y-coordinate of the parser
            int expectedX = 75; // set the expected X-coordinate
            int expectedY = 25; // set the expected Y-coordinate


            parser.ParseAndExecuteCommand($"drawto {expectedX},{expectedY}"); // calls parse and execute the command with expected coordinates

            // Assert
            Assert.That(parser.shapes.Count, Is.EqualTo(1)); // Assert that only one shape was added to the shapes list
            Assert.IsInstanceOf<LineShape>(parser.shapes[0]); // Assert that the added shape is an instance of LineShape
            var line = (LineShape)parser.shapes[0]; // cast the added shape to a LineShape
            Assert.That(line.x, Is.EqualTo(parser.currentX)); // Assert that the X-coordinate of the added shape matches the current X-coordinate of the parser
            Assert.That(line.y, Is.EqualTo(parser.currentY)); // Assert that the Y-coordinate of the added shape matches the current Y-coordinate of the parser
            Assert.That(line.x, Is.EqualTo(expectedX)); // Assert that the X-coordinate of the end point of the line matches the expected X-coordinate
            Assert.That(line.y, Is.EqualTo(expectedY)); // Assert that the Y-coordinate of the end point of the line matches the expected Y-coordinate
        }



        [Test]/// <summary>
              /// public void ParseAndExecuteCommand_MoveTo_CorrectlyUpdatesCurrentPosition(): This is a method signature for the public 
              /// method that we are defining.
              /// It returns nothing, takes no parameters, and is named ParseAndExecuteCommand_MoveTo_CorrectlyUpdatesCurrentPosition.
              /// </summary>
        public void ParseAndExecuteCommand_MoveTo_CorrectlyUpdatesCurrentPosition()
        {
            var parser = new CommandParser(graphics); //creates a new instance of the CommandParser class,
            int expectedX = 50;
            int expectedY = 75;

            parser.ParseAndExecuteCommand($"moveto {expectedX},{expectedY}"); //call the ParseAndExecuteCommand method of the parser object, passing in a string command of the form "moveto X,Y", where X is expectedX and Y is expectedY

            Assert.That(parser.currentX, Is.EqualTo(expectedX)); //call the ParseAndExecuteCommand method of the parser object, passing in a string command of the form "moveto X,Y", where X is expectedX and Y is expectedY
            Assert.That(parser.currentY, Is.EqualTo(expectedY));

        }
    }
}
