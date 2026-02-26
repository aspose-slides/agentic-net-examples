using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustCellMargins
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 150, 150, 150 };
            double[] rowHeights = new double[] { 100, 100, 100 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Adjust margins for each cell in the table
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int cellIndex = 0; cellIndex < table.Rows[rowIndex].Count; cellIndex++)
                {
                    Aspose.Slides.ICell cell = table.Rows[rowIndex][cellIndex];
                    cell.MarginTop = 5.0;
                    cell.MarginBottom = 5.0;
                    cell.MarginLeft = 5.0;
                    cell.MarginRight = 5.0;
                }
            }

            // Save the presentation
            presentation.Save("AdjustCellMargins_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}