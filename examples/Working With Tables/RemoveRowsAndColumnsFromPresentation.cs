using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide (index 0)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define column widths and row heights for the table
        double[] colWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide at position (50, 50)
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

        // Remove the second row (index 1) without removing attached rows
        table.Rows.RemoveAt(1, false);

        // Remove the first column (index 0) without removing attached columns
        table.Columns.RemoveAt(0, false);

        // Save the presentation before exiting
        pres.Save("RemovedRowsColumns.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}