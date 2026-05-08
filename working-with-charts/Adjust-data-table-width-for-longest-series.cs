using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableColumnWidthAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Define initial column widths and row heights
                double[] columnWidths = { 100, 150 };
                double[] rowHeights = { 30, 30, 30, 30 };

                // Add a table to the slide
                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Sample series names to be placed in the first column
                string[] seriesNames = { "Alpha", "BetaSeries", "GammaLongName", "Delta" };

                // Populate the first column with series names
                for (int rowIndex = 0; rowIndex < seriesNames.Length; rowIndex++)
                {
                    // Use column index first, then row index as required by ITable indexer
                    ICell cell = table[0, rowIndex];
                    cell.TextFrame.Text = seriesNames[rowIndex];
                }

                // Determine the longest series name length
                int maxLength = 0;
                for (int rowIndex = 0; rowIndex < seriesNames.Length; rowIndex++)
                {
                    ICell cell = table[0, rowIndex];
                    int length = cell.TextFrame.Text.Length;
                    if (length > maxLength)
                        maxLength = length;
                }

                // Adjust the first column width based on the longest name (approx. 7 points per character)
                double newWidth = maxLength * 7.0;
                table.Columns[0].Width = newWidth;

                // Save the presentation
                try
                {
                    pres.Save("AdjustedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions (e.g., file I/O)
                }
            }
        }
    }
}