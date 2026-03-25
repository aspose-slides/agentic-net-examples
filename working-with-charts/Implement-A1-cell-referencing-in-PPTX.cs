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
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : null;
            string outputPath = "A1ReferenceDemo.pptx";

            // Load existing presentation if provided, otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (!string.IsNullOrEmpty(inputPath))
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Error: Input file not found - " + inputPath);
                    return;
                }
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define table dimensions
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50 };
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Example A1 address
            string a1Address = "B2";

            // Parse A1 address to zero‑based row and column indexes
            int targetRow;
            int targetColumn;
            ParseA1Address(a1Address, out targetRow, out targetColumn);

            // Ensure the address is within the table bounds
            if (targetRow < 0 || targetRow >= table.Rows.Count ||
                targetColumn < 0 || targetColumn >= table.Columns.Count)
            {
                Console.WriteLine("Error: A1 address out of table bounds.");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Set text in the referenced cell
            Aspose.Slides.ICell cell = table[targetRow, targetColumn];
            cell.TextFrame.Text = "Cell " + a1Address;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Converts an A1 style address (e.g., "C3") to zero‑based row and column indexes
        private static void ParseA1Address(string address, out int rowIndex, out int columnIndex)
        {
            columnIndex = 0;
            rowIndex = 0;

            // Separate letters and numbers
            int i = 0;
            while (i < address.Length && Char.IsLetter(address[i]))
            {
                columnIndex = columnIndex * 26 + (Char.ToUpper(address[i]) - 'A' + 1);
                i++;
            }
            while (i < address.Length && Char.IsDigit(address[i]))
            {
                rowIndex = rowIndex * 10 + (address[i] - '0');
                i++;
            }

            // Convert to zero‑based indexes
            columnIndex -= 1;
            rowIndex -= 1;
        }
    }
}