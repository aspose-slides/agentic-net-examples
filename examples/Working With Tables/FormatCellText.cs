using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 150, 150, 150 };
                double[] rowHeights = new double[] { 60, 60, 60 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate cells with sample text
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        table.Rows[row][col].TextFrame.Text = $"R{row + 1}C{col + 1}";
                    }
                }

                // Create a portion format to define font style, size, and color
                Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                portionFormat.FontHeight = 24f;                     // Font size
                portionFormat.FontBold = NullableBool.True;         // Bold style
                portionFormat.FontItalic = NullableBool.False;      // Not italic
                portionFormat.FillFormat.FillType = FillType.Solid;
                portionFormat.FillFormat.SolidFillColor.Color = Color.Blue; // Font color

                // Apply the formatting to all cells in the table
                table.SetTextFormat(portionFormat);

                // Save the presentation
                presentation.Save("FormattedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}