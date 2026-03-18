using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation from a file
            Presentation presentation = new Presentation("input.pptx");

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a table
            Table table = (Table)slide.Shapes[0];

            // Define the row and column indices of the target cell (zero‑based)
            int rowIndex = 1;
            int columnIndex = 2;

            // Retrieve the cell at the specified position
            ICell cell = table[rowIndex, columnIndex];

            // Get the text contained in the cell's TextFrame
            string cellText = cell.TextFrame.Text;

            // Output the retrieved text
            Console.WriteLine("Cell text: " + cellText);

            // Save the presentation (required before exiting)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}