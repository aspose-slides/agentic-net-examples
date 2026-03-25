using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableA1ReferenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Attempt to get the first shape as a table
                ITable table = slide.Shapes[0] as ITable;
                if (table == null)
                {
                    Console.WriteLine("Error: No table found on the first slide.");
                    return;
                }

                // Example A1 cell reference
                string a1Reference = "C3";

                // Convert A1 notation to zero‑based column and row indexes
                int columnIndex = GetColumnIndexFromA1(a1Reference);
                int rowIndex = GetRowIndexFromA1(a1Reference);

                // Validate indexes against table dimensions
                if (columnIndex < 0 || columnIndex >= table.Columns.Count ||
                    rowIndex < 0 || rowIndex >= table.Rows.Count)
                {
                    Console.WriteLine("Error: A1 reference out of table bounds.");
                    return;
                }

                // Retrieve the cell using the indexer (column, row)
                ICell cell = table[columnIndex, rowIndex];

                // Modify the cell's text
                cell.TextFrame.Text = "Updated via A1";

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }

        // Converts the column letters of an A1 reference to a zero‑based column index
        private static int GetColumnIndexFromA1(string a1)
        {
            int i = 0;
            while (i < a1.Length && Char.IsLetter(a1[i]))
                i++;

            string columnPart = a1.Substring(0, i).ToUpperInvariant();
            int columnNumber = 0;
            foreach (char c in columnPart)
            {
                columnNumber = columnNumber * 26 + (c - 'A' + 1);
            }
            return columnNumber - 1; // zero‑based
        }

        // Extracts the row number from an A1 reference and converts it to a zero‑based index
        private static int GetRowIndexFromA1(string a1)
        {
            int i = 0;
            while (i < a1.Length && Char.IsLetter(a1[i]))
                i++;

            string rowPart = a1.Substring(i);
            int rowNumber = Int32.Parse(rowPart);
            return rowNumber - 1; // zero‑based
        }
    }
}