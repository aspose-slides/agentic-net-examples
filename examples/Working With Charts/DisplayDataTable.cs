using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights (in points)
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 40, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Populate the table cells with sample text and set borders
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                // Set cell text
                table.Rows[row][col].TextFrame.Text = $"R{row + 1}C{col + 1}";

                // Set top border
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderTop.Width = 1;

                // Set bottom border
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderBottom.Width = 1;

                // Set left border
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderLeft.Width = 1;

                // Set right border
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
                table.Rows[row][col].CellFormat.BorderRight.Width = 1;
            }
        }

        // Save the presentation to disk
        presentation.Save("DataTablePresentation.pptx", SaveFormat.Pptx);
    }
}