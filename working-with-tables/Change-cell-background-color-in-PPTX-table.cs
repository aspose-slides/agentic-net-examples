using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Try to get the first shape as a table; if not present, create a new table
            ITable table = slide.Shapes[0] as ITable;
            if (table == null)
            {
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50 };
                table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
            }

            // Update background color of the cell at row 0, column 0
            ICell cell = table[0, 0];
            cell.CellFormat.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.FillFormat.SolidFillColor.Color = Color.ForestGreen;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}