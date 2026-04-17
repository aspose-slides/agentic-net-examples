using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "VerticallyAlignedTable.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] cols = new double[] { 100, 100, 100 };
        double[] rows = new double[] { 50, 50, 50 };

        // Add a table to the slide
        ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Add text to the first cell
        table[0, 0].TextFrame.Text = "Centered Text";

        // Vertically align text to middle
        ICell cell = table[0, 0];
        cell.TextAnchorType = TextAnchorType.Center;
        cell.TextVerticalType = TextVerticalType.Vertical270;

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}