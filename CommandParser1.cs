//This method shows the Invalid Command Message Box
        public void ShowSyntaxErrorMessage()
        {
            MessageBox.Show("Invalid Parameters, Please Use Correct Command");
        }
        //This method is used if you have multiple commands
        private string GetNextCommand(string[] parts, int index)
        {
            StringBuilder sb = new StringBuilder();
            int i = index + 1;
            while (i < parts.Length && !parts[i].Equals("end", StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(parts[i]).Append(' ');
                i++;
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        ///The MoveTo method is used to set the current position to a specified position without drawing a shape. The Clear method is used to clear the canvas and the list of shapes. The Reset method is used to reset the Pen object and clear the canvas and list of shapes
        /// </summary>
       
        private void MoveTo(int x, int y)
        {
            // Set the color of the pen to ControlDark
            pen.Color = SystemColors.ControlDark;

            // Draw an ellipse at the current position size of 10x10 using the current pen
            graphics.DrawEllipse(pen, currentX, currentY, 10, 10);

            // Fill the ellipse with the ControlDark color using a SolidBrush
            graphics.FillEllipse(new SolidBrush(SystemColors.ControlDark), new Rectangle(currentX, currentY, 10, 10));

            // Set the StartCap and EndCap of the pen to Round
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            // Set the Width of the pen to 1
            pen.Width = 1;

            // Set the color of the pen to Red
            pen.Color = Color.Red;

            // Set the DashStyle of the pen to Solid
            pen.DashStyle = DashStyle.Solid;

            // Set the Alignment of the pen to Inset
            pen.Alignment = PenAlignment.Inset;

            // Dispose the current pen object to free up resources and create a new pen object with Red color and Width of 1
            pen.Dispose();
            pen = new Pen(Color.Red);
            pen.Width = 1;

            // Set the current position to the new position and draws an ellipse at the new position
            currentX = x;
            currentY = y;
            graphics.DrawEllipse(pen, x, y, 10, 10);
        }
        /// <summary>
        //The class contains methods for drawing shapes.
        /// 
        /// </summary>

        private void DrawTo(int x, int y)
        {
            // Creatse a new LineShape object with the current position and the new position provided by the user
            LineShape line = new LineShape(currentX, currentY, x, y);

            // Adds the new LineShape object to the shapes list
            shapes.Add(line);

            // Draws the LineShape object using the graphics object
            line.Draw(graphics);

            // Sets the current position to the new position provided by the user
            currentX = x;
            currentY = y;
        }
        public void Reset()
        {
            // Disposes of the old pen object and create a new one with default black color
            pen.Dispose();
            pen = new Pen(Color.Black);

            // Clears the list of shapes and the graphics area with a dark gray color
            shapes.Clear();
            graphics.Clear(Color.DarkGray);

            // Moves the pen to the starting position which is (0, 0)
            MoveTo(0, 0);
        }
        public void Clear()
        {
            // Disposes of the old pen object and create a new one with red color
            pen.Dispose();
            pen = new Pen(Color.Red);

            // Clear the list of shapes and the graphics area with a white color
            shapes.Clear();
            graphics.Clear(Color.White);
        }
        private void Circle(int radius)
        {
            // Creates a new CircleShape object with the current position and radius
            CircleShape circle = new CircleShape(currentX, currentY, radius);

            // Adds the circle object to the list of shapes
            shapes.Add(circle);

            // Draws the circle on the graphics area
            circle.Draw(graphics);
        }

        private void Rectangle(int width, int height)
        {
            // Creates a new rectangle shape
            var rectangle = new RectangleShape(currentX, currentY, width, height,pen);

            // Adds the rectangle to the list of shapes
            shapes.Add(rectangle);

            // Draws the rectangle
            rectangle.Draw(graphics);
        }





    }
}
