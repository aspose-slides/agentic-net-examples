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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] colWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

            // Remove the second row (index 1) without removing attached rows
            table.Rows.RemoveAt(1, false);

            // Remove the first column (index 0) without removing attached columns
            table.Columns.RemoveAt(0, false);

            // Save the presentation
            pres.Save("ModifiedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}