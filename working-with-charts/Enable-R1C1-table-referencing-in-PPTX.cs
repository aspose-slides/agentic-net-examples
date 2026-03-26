using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    // Parses an R1C1 reference (e.g., "R2C3") and returns the corresponding cell.
    private static ICell GetCellByR1C1(ITable table, string r1c1Reference)
    {
        if (table == null || string.IsNullOrEmpty(r1c1Reference))
            return null;

        // Remove any whitespace and convert to upper case.
        string reference = r1c1Reference.Trim().ToUpperInvariant();

        // Expected format: R<rowNumber>C<colNumber>
        if (!reference.StartsWith("R") || !reference.Contains("C"))
            return null;

        int rowIndex = -1;
        int colIndex = -1;

        try
        {
            int cPos = reference.IndexOf('C');
            string rowPart = reference.Substring(1, cPos - 1);
            string colPart = reference.Substring(cPos + 1);

            // Convert to zero‑based indexes.
            rowIndex = int.Parse(rowPart) - 1;
            colIndex = int.Parse(colPart) - 1;
        }
        catch
        {
            return null;
        }

        // Validate indexes.
        if (rowIndex < 0 || colIndex < 0 || rowIndex >= table.Rows.Count || colIndex >= table.Columns.Count)
            return null;

        return table[rowIndex, colIndex];
    }

    static void Main(string[] args)
    {
        // Input and output file paths.
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation.
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide.
        ISlide slide = presentation.Slides[0];

        // Assume the first shape is a table.
        ITable table = slide.Shapes[0] as ITable;
        if (table == null)
        {
            Console.WriteLine("No table found on the first slide.");
            // Save the presentation unchanged.
            presentation.Save(outputPath, SaveFormat.Pptx);
            return;
        }

        // Example: Get cell at R2C3 (second row, third column) using R1C1 notation.
        ICell targetCell = GetCellByR1C1(table, "R2C3");
        if (targetCell != null && targetCell.TextFrame != null)
        {
            // Set text in the selected cell.
            targetCell.TextFrame.Text = "R1C1 Addressed";
        }

        // Example: Relative addressing – get cell one row below and one column to the right of R2C3.
        ICell baseCell = GetCellByR1C1(table, "R2C3");
        if (baseCell != null)
        {
            int baseRow = baseCell.FirstRowIndex;
            int baseCol = baseCell.FirstColumnIndex;
            int relativeRow = baseRow + 1; // one row down
            int relativeCol = baseCol + 1; // one column right

            if (relativeRow < table.Rows.Count && relativeCol < table.Columns.Count)
            {
                ICell relativeCell = table[relativeRow, relativeCol];
                if (relativeCell.TextFrame != null)
                {
                    relativeCell.TextFrame.Text = "Relative Cell";
                }
            }
        }

        // Save the modified presentation.
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}