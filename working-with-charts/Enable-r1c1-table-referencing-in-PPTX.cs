using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace R1C1TableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Helper to convert R1C1 string to zero‑based row and column indexes
                (int row, int col) ParseR1C1(string address)
                {
                    var rIndex = address.IndexOf('R');
                    var cIndex = address.IndexOf('C');
                    var rowPart = address.Substring(rIndex + 1, cIndex - rIndex - 1);
                    var colPart = address.Substring(cIndex + 1);
                    int row = int.Parse(rowPart) - 1;
                    int col = int.Parse(colPart) - 1;
                    return (row, col);
                }

                // Example: set text in cell R2C3
                var (rowIdx, colIdx) = ParseR1C1("R2C3");
                if (rowIdx < table.Rows.Count && colIdx < table.Columns.Count)
                {
                    var cell = table[rowIdx, colIdx];
                    cell.TextFrame.Text = "R1C1 Example";
                }

                // Example: relative addressing from base cell R1C1 with offset (+1 row, +2 col)
                var (baseRow, baseCol) = ParseR1C1("R1C1");
                int offsetRow = 1;
                int offsetCol = 2;
                int targetRow = baseRow + offsetRow;
                int targetCol = baseCol + offsetCol;
                if (targetRow < table.Rows.Count && targetCol < table.Columns.Count)
                {
                    var targetCell = table[targetRow, targetCol];
                    targetCell.TextFrame.Text = "Relative Cell";
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}