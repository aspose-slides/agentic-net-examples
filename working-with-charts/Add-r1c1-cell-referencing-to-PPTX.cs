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
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Find the first table on the slide
                Aspose.Slides.ITable table = null;
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.ITable tempTable = slide.Shapes[shapeIndex] as Aspose.Slides.ITable;
                    if (tempTable != null)
                    {
                        table = tempTable;
                        break;
                    }
                }

                if (table != null)
                {
                    // Example R1C1 reference (absolute addressing)
                    string r1c1Reference = "R2C3";

                    // Parse the R1C1 string to zero‑based row and column indexes
                    int rowIndex = -1;
                    int columnIndex = -1;
                    int rPos = r1c1Reference.IndexOf('R');
                    int cPos = r1c1Reference.IndexOf('C');
                    if (rPos >= 0 && cPos > rPos)
                    {
                        string rowPart = r1c1Reference.Substring(rPos + 1, cPos - rPos - 1);
                        string colPart = r1c1Reference.Substring(cPos + 1);
                        rowIndex = Int32.Parse(rowPart) - 1;      // Convert to zero‑based
                        columnIndex = Int32.Parse(colPart) - 1;   // Convert to zero‑based
                    }

                    // Validate indexes and update the cell text
                    if (rowIndex >= 0 && rowIndex < table.Rows.Count &&
                        columnIndex >= 0 && columnIndex < table.Columns.Count)
                    {
                        Aspose.Slides.ICell targetCell = table[rowIndex, columnIndex];
                        if (targetCell != null && targetCell.TextFrame != null)
                        {
                            targetCell.TextFrame.Text = "Updated via R1C1";
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}