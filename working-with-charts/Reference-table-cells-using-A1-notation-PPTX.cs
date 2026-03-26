using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableA1ReferenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
                // Add a table to the first slide for demonstration
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                double[] columnWidths = new double[] { 100, 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50, 50 };
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
                // Optional: set some default text in each cell
                for (int r = 0; r < table.Rows.Count; r++)
                {
                    for (int c = 0; c < table.Rows[r].Count; c++)
                    {
                        Aspose.Slides.ICell cell = table[c, r];
                        cell.TextFrame.Text = $"R{r + 1}C{c + 1}";
                    }
                }
            }

            // Get the first slide and the first table on it
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            Aspose.Slides.ITable targetTable = firstSlide.Shapes[0] as Aspose.Slides.ITable;
            if (targetTable == null)
            {
                Console.WriteLine("No table found on the first slide.");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Example A1 cell references
            string[] a1References = new string[] { "A1", "B2", "C3", "D4" };
            foreach (string a1 in a1References)
            {
                int columnIndex;
                int rowIndex;
                if (TryParseA1Reference(a1, out columnIndex, out rowIndex))
                {
                    // Ensure indices are within table bounds
                    if (columnIndex >= 0 && columnIndex < targetTable.Columns.Count &&
                        rowIndex >= 0 && rowIndex < targetTable.Rows.Count)
                    {
                        Aspose.Slides.ICell cell = targetTable[columnIndex, rowIndex];
                        cell.TextFrame.Text = $"Updated {a1}";
                    }
                    else
                    {
                        Console.WriteLine($"A1 reference {a1} is out of table bounds.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid A1 reference: {a1}");
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Parses an A1 style reference (e.g., "B3") into zero‑based column and row indexes.
        private static bool TryParseA1Reference(string a1, out int columnIndex, out int rowIndex)
        {
            columnIndex = -1;
            rowIndex = -1;
            if (string.IsNullOrEmpty(a1))
                return false;

            Match match = Regex.Match(a1.ToUpperInvariant(), @"^([A-Z]+)(\d+)$");
            if (!match.Success)
                return false;

            string columnPart = match.Groups[1].Value;
            string rowPart = match.Groups[2].Value;

            // Convert column letters to number (A=0, B=1, ..., Z=25, AA=26, etc.)
            columnIndex = 0;
            foreach (char ch in columnPart)
            {
                columnIndex *= 26;
                columnIndex += (ch - 'A' + 1);
            }
            columnIndex -= 1; // zero‑based

            // Convert row number to zero‑based index
            int parsedRow;
            if (!int.TryParse(rowPart, out parsedRow))
                return false;
            rowIndex = parsedRow - 1;

            return true;
        }
    }
}