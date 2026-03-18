using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape as a table
            Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                return;
            }

            // Specify the row index to retrieve
            int rowIndex = 1; // example index

            if (rowIndex < 0 || rowIndex >= table.Rows.Count)
            {
                Console.WriteLine("Row index out of range.");
                return;
            }

            // Retrieve the row
            Aspose.Slides.IRow row = table.Rows[rowIndex];
            Console.WriteLine($"Row {rowIndex} contains {row.Count} cells.");

            // Iterate through cells in the row and display properties
            for (int cellIdx = 0; cellIdx < row.Count; cellIdx++)
            {
                Aspose.Slides.ICell cell = row[cellIdx];
                string cellText = cell.TextFrame?.Text ?? string.Empty;
                double cellWidth = cell.Width;
                double cellHeight = cell.Height;

                Console.WriteLine($"Cell [{cellIdx}] - Text: \"{cellText}\", Width: {cellWidth}, Height: {cellHeight}");
            }

            // Save the (unchanged) presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}