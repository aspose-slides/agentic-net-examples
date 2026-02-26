using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation from file
        Presentation presentation = new Presentation("input.pptx");

        // Get the first slide in the presentation
        ISlide slide = presentation.Slides[0];

        // Assume the first shape on the slide is a table and cast it
        ITable table = (ITable)slide.Shapes[0];

        // Access the cell at column index 0 and row index 0
        ICell cell = table[0, 0];

        // Retrieve the text frame of the cell
        ITextFrame textFrame = cell.TextFrame;

        // Read the text content of the cell
        string cellText = textFrame.Text;

        // Output the cell text to the console
        Console.WriteLine("Cell[0,0] text: " + cellText);

        // Save the presentation to a new file
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}