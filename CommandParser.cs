/<summary>
/// This line imports the System.Drawing.Drawing2D which allows access to classes for advanced 2D graphics functionality.
///</summary>
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Text;
namespace DrawingApp
{
    /// <summary>
    /// Class called commandParser. Includes method to parse and execute commands in the form of a string.
    /// </summary>
    public class CommandParser
    {
        public int currentX;
        public int currentY;
        public Pen pen;
        private Graphics graphics;
        public  List<Shape> shapes;
       
        public CommandParser(Graphics graphics)
        {
            this.graphics = graphics;
            pen = new Pen(Color.Black);
            shapes = new List<Shape>();
        }

        public void ParseAndExecuteCommand(string command)
        {
            ///<summary>
            /// this line declares an array of strings which are called parts. The split method sereprates the string into an array.
            /// </summary>
            string[] parts = command.ToLower().Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);

            //This if statement checks if the parts array is empty.
            if (parts.Length == 0)
            {
                return;
            }
            // Declares a string variable which is called cmd, it is assigned to the first elemt of the parts array
            string cmd = parts[0].ToLower();
            //This switch statement checks the value of cmd and executes the corresponding case.
            switch (cmd)
            {
                case "moveto":

                    //This if statement checks if the parts array has a length of 3 and if the elements can be parsed as intergers.
                    //If the conditions are met, the MoveTo method is called with the parsed interger values as an argument.
                    // if the conditions aren’t met, the ShowSyntaxErrorMessage is called and a error is displayed.

                    if (parts.Length == 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
                    {
                        MoveTo(x, y);
                    }
                    else
                    {
                        Console.WriteLine("Invalid parameters for moveto command");
                        ShowSyntaxErrorMessage();
                    }
                    break;
                //This case handles the "drawto" command.
                
                case "drawto":
                    

                    if (parts.Length == 3 && int.TryParse(parts[1], out int x2) && int.TryParse(parts[2], out int y2))
                    {
                        DrawTo(x2, y2);
                    }
                    else
                    {
                        Console.WriteLine("Invalid parameters for drawto command");
                        ShowSyntaxErrorMessage();
                    }
                    break;
                //This case handles the "circle" command. 
                case "circle":
                    // Checks whether a radius has been provided.If it has it calls the circle method and if it hasn’t, an error is shown and the ShowSyntaxErrorMessage is called.
                    if (parts.Length == 2 && int.TryParse(parts[1], out int radius))
                    {
                        Circle(radius);
                    }
                    else
                    {
                        Console.WriteLine("Invalid parameter for circle command");
                        ShowSyntaxErrorMessage();
                    }
                    break;
                case "rectangle":
                   // Checks whether the width and height have been provide. If it has then it calls the rectangle method and if there is anything wrong with the command, an error is shown and the showSyntaxErrrorMessage method is called..
                    if (parts.Length == 3 && int.TryParse(parts[1], out int width) && int.TryParse(parts[2], out int height))
                    {
                        Rectangle(width, height);
                    }
                    else
                    {
                        Console.WriteLine("Invalid parameters for rectangle command");
                        ShowSyntaxErrorMessage();
                    }
                    break;
                //The "clear" case calls the "Clear" method.
                case "clear":
                    Clear();
                    break;
                //The "reset" case calls the "Reset" method
                case "reset":
                    Reset();
                    break;
                //If none of the cases match the commands, the program outputs an error message and calls the "ShowSyntaxErrorMessage" method
                default:
                    Console.WriteLine("Invalid command");
                    ShowSyntaxErrorMessage();
                    break;
            }
        }
