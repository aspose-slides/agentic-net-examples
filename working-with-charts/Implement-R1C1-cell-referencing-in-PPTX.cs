using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first table on the first slide
            Aspose.Slides.ITable table = presentation.Slides[0].Shapes[0] as Aspose.Slides.ITable;
            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                return;
            }

            // Example R1C1 reference
            string r1c1Reference = "R2C3";

            // Parse R1C1 to zero‑based indexes
            int rowIndex = 0;
            int colIndex = 0;
            if (r1c1Reference.StartsWith("R") && r1c1Reference.Contains("C"))
            {
                string[] parts = r1c1Reference.Substring(1).Split('C');
                int.TryParse(parts[0], out rowIndex);
                int.TryParse(parts[1], out colIndex);
                rowIndex -= 1; // convert to zero‑based
                colIndex -= 1;
            }

            // Validate indexes and update cell text
            if (rowIndex >= 0 && rowIndex < table.Rows.Count && colIndex >= 0 && colIndex < table.Columns.Count)
            {
                Aspose.Slides.ICell cell = table[rowIndex, colIndex];
                if (cell != null && cell.TextFrame != null)
                {
                    cell.TextFrame.Text = "Updated via R1C1";
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}