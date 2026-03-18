using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths (in points)
                double[] columnWidths = new double[] { 100, 100, 100 };

                // Define row heights (in points)
                double[] rowHeights = new double[] { 40, 30, 30, 30 };

                // Add a table to the slide with the specified dimensions
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Example: set text in the first cell
                table.Rows[0][0].TextFrame.Text = "Header";

                // Save the presentation to disk
                presentation.Save("TableRowHeights.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}