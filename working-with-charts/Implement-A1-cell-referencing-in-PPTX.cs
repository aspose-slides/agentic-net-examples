using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesA1Reference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "A1ReferenceTable.pptx");

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Example: set text in cell B2 using A1 notation
            ICell cellB2 = GetCellByA1(table, "B2");
            cellB2.TextFrame.Text = "Cell B2";

            // Example: set text in cell C4 using A1 notation
            ICell cellC4 = GetCellByA1(table, "C4");
            cellC4.TextFrame.Text = "Cell C4";

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }

        // Helper method to convert A1 notation to table cell
        private static ICell GetCellByA1(ITable table, string address)
        {
            // Parse column letters
            int col = 0;
            int i = 0;
            while (i < address.Length && Char.IsLetter(address[i]))
            {
                col = col * 26 + (Char.ToUpper(address[i]) - 'A' + 1);
                i++;
            }
            col--; // zero‑based index

            // Parse row number
            int row = int.Parse(address.Substring(i)) - 1; // zero‑based index

            // Table indexer expects column first, then row
            return table[col, row];
        }
    }
}