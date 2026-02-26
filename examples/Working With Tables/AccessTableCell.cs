using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Access a specific cell using column and row indices (zero‑based)
            // For example, column index 1, row index 2
            ICell cell = table[1, 2];

            // Set text in the accessed cell
            cell.TextFrame.Text = "Accessed Cell";

            // Save the presentation
            pres.Save("AccessCell.pptx", SaveFormat.Pptx);
        }
    }
}