
        /// <summary>
        ///This method is called when form1 is resized. It makes a new bitmap object which acts a buffer and draws the shaping using the draw method then it assigns the buffet to the graphic object which allows it to be displayed on the screen.
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            // Creates a new bitmap whichs act as a buffer
            Bitmap buffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);

            // Draws the existing shapes onto the buffer
            using (Graphics g = Graphics.FromImage(buffer))
            {
                foreach (Shape shape in commandParser.shapes)
                {
                    shape.Draw(g);
                }
            }

            drawingPanel.CreateGraphics().DrawImage(buffer, 0, 0);
        }

        /// <summary>
        ///This method is called when form1 is loaded. It creates a new bitmap object which acts as a buffer, then it draws all the shapes onto the buffer using the draw method.
        /// </summary>


        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "moveto 100,100";
        }

        ///<summary>
        /// This method is called when the buttonMoveTo is pressed.It uses the moveto command with the coordinates.
        ///</summary>
        private void btnDrawTo_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "drawto 100,100";
        }

        /// <summary>
        ///This method is called when btnCircle is pressed..
        /// </summary>

        private void btnCircle_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "circle 20";
        }

        /// <summary>
        ///This method is called when the buttonRect button is clicked.
        /// </summary>
        

        private void buttonRect_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "rectangle 100,100";
        }

        /// <summary>
        ///This method is called when the “clear” button is pressed. It clears the text in the command text box, command history text box and the shapes in the CommandParser object.
        /// </summary>

        private void btnClear_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "";
            commandHistoryTextBox.Clear();
            commandParser.Clear();
            
        }
    
        private void buttonReset_Click(object sender, EventArgs e)
        {
            commandParser.Reset();
        }
>
        private void button2_Click(object sender, EventArgs e)
        {
            commandHistoryTextBox.AppendText(commandTextBox.Text + "\n");
            commandParser.ParseAndExecuteCommand(commandTextBox.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Command History";
            saveFileDialog1.FileName = ""; // allows you to specify filename
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog1.FileName, commandHistoryTextBox.Lines);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Load Command History";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] commandHistory = File.ReadAllLines(openFileDialog1.FileName);
                foreach(string command in commandHistory)
                {
                    commandHistoryTextBox.Lines = commandHistory;
                    commandParser.ParseAndExecuteCommand(command);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
