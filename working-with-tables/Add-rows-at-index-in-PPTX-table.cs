using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddRowsToTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape on the slide is a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Index at which the new row will be inserted
                int insertIndex = 1; // Insert after the first row (0‑based)

                // Use the first row as a template for the new row
                Aspose.Slides.IRow templateRow = table.Rows[0];

                // Insert a clone of the template row at the specified index
                // withAttachedRows = false (no attached rows to copy)
                Aspose.Slides.IRow[] insertedRows = table.Rows.InsertClone(insertIndex, templateRow, false);

                // Optional: set text for each cell in the newly inserted row
                Aspose.Slides.IRow newRow = insertedRows[0];
                for (int cellIndex = 0; cellIndex < newRow.Count; cellIndex++)
                {
                    newRow[cellIndex].TextFrame.Text = $"New Row {insertIndex}, Cell {cellIndex}";
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}