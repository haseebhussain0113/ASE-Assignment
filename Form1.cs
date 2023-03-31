using System.Windows.Forms;

namespace DrawingApp
{
    
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private CommandParser commandParser;

        /// <summary>
        /// The constructor for form 1 which allow the graphics object to be linked with the drawingpanel
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            graphics = drawingPanel.CreateGraphics();
            commandParser = new CommandParser(graphics);

        }


        /// <summary>
        ///This methods is called when button1 is pressed. Adds the new commands to the commandHistoryTextbox which then parses the command to run.
        /// </summary>


        private void Form1_Resize(object sender, EventArgs e)
        {
                // Creates a new bitmap to act as a buffer
                Bitmap buffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);

                // Draws the existing shapes onto the buffer
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    foreach (Shape shape in commandParser.shapes)
                    {
                        shape.Draw(g);
                    }
                }

                // Assign the buffer to the panel's graphics object
                drawingPanel.CreateGraphics().DrawImage(buffer, 0, 0);

        }

        /// <summary>
        ///This method is called when form1 is resized. It makes a new bitmap object which acts a buffer and draws the shaping using the draw method then it assigns the buffet to the graphic object which allows it to be displayed on the screen.
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            // Creates a new bitmap to act as a buffer
            Bitmap buffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);

            // Draws the existing shapes onto the buffer
            using (Graphics g = Graphics.FromImage(buffer))
            {
                foreach (Shape shape in commandParser.shapes)
                {
                    shape.Draw(g);
                }
            }

            // Assigns the buffer to the panel's graphics object
            drawingPanel.CreateGraphics().DrawImage(buffer, 0, 0);
        }
