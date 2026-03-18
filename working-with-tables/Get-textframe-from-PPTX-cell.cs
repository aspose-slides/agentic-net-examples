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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a table
            Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;

            if (table != null)
            {
                // Retrieve a specific cell (row 0, column 0)
                Aspose.Slides.ICell cell = table[0, 0];

                // Get the TextFrame associated with the cell
                Aspose.Slides.ITextFrame textFrame = cell.TextFrame;

                // Output the text contained in the cell's TextFrame
                Console.WriteLine("Cell Text: " + textFrame.Text);
            }
            else
            {
                Console.WriteLine("No table found on the first slide.");
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}