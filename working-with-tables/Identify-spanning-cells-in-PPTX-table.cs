using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace IdentifySpanningCells
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output file paths
                string dataDir = @"C:\Data\";
                string inputFile = "input.pptx";
                string outputFile = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(dataDir + inputFile);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first table on the slide
                Aspose.Slides.ITable table = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.ITable)
                    {
                        table = (Aspose.Slides.ITable)shape;
                        break;
                    }
                }

                if (table != null)
                {
                    // Iterate through all cells and detect spanning cells
                    for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                        {
                            // Note: ITable indexer expects column index first, then row index
                            Aspose.Slides.ICell cell = table[colIndex, rowIndex];

                            // Check if the cell spans multiple rows or columns
                            if (cell.RowSpan > 1 || cell.ColSpan > 1)
                            {
                                Console.WriteLine(
                                    $"Cell at column {colIndex}, row {rowIndex} spans {cell.ColSpan} column(s) and {cell.RowSpan} row(s).");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No table found on the first slide.");
                }

                // Save the presentation (even if unchanged)
                presentation.Save(dataDir + outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}