using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found. A new presentation will be created.");
        }

        try
        {
            using (Aspose.Slides.Presentation pres = File.Exists(inputPath) ? new Aspose.Slides.Presentation(inputPath) : new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Define table dimensions
                double[] columnWidths = { 100, 100, 100 };
                double[] rowHeights = { 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Merge cells horizontally (first row, first two columns)
                table.MergeCells(table[0, 0], table[1, 0], false);
                // Merge cells vertically (first column, rows 2 and 3)
                table.MergeCells(table[0, 1], table[0, 2], false);

                // Identify merged cells and log their spans
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                    {
                        Aspose.Slides.ICell cell = table[colIndex, rowIndex];
                        if (cell.IsMergedCell)
                        {
                            Console.WriteLine($"Merged cell at Row {rowIndex}, Column {colIndex}: RowSpan = {cell.RowSpan}, ColSpan = {cell.ColSpan}");
                        }
                    }
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}