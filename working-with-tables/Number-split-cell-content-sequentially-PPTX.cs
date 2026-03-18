using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace NumberSplitCellContent
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

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape is a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Target a specific cell (e.g., first row, first column)
                Aspose.Slides.ICell cell = table[0, 0];
                Aspose.Slides.ITextFrame textFrame = cell.TextFrame;

                // Split the cell's text into columns
                string[] columns = textFrame.SplitTextByColumns();

                // Apply sequential numbering to each column's content
                for (int i = 0; i < columns.Length; i++)
                {
                    columns[i] = (i + 1).ToString() + ". " + columns[i];
                }

                // Recombine the columns into a single string (using line breaks)
                string newText = string.Join("\n", columns);

                // Update the cell's text (TextFrame is read‑only, but its Text property is writable)
                textFrame.Text = newText;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}