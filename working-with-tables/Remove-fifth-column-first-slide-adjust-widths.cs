// -----------------------------------------------------------------------------
// Example: Remove fifth column first slide adjust widths using C#
//
// Description:
// Demonstrates how to remove the fifth column from the first slide's table and
// evenly redistribute the remaining column widths using C# and Aspose.Slides for .NET.
// The example creates a sample presentation if none exists, processes the table,
// and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Fifth, Column, First Slide,
// Table, Adjust Widths, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of a specific column from a table on the first slide.
// - Rebalance column widths after column deletion in PowerPoint presentations.
// - Build .NET tools for table manipulation within PPTX files.
// - Validate and transform presentation layouts programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableColumnRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure the input file exists; if not, create a sample presentation with a table.
            if (!File.Exists(inputPath))
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = pres.Slides[0];
                    double[] columnWidths = new double[] { 100, 100, 100, 100, 100 };
                    double[] rowHeights = new double[] { 50, 50 };
                    Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlide slide = pres.Slides[0];
                    Aspose.Slides.ITable table = null;

                    // Locate the first table on the slide.
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.ITable)
                        {
                            table = (Aspose.Slides.ITable)shape;
                            break;
                        }
                    }

                    if (table != null && table.Columns.Count > 5)
                    {
                        // Remove the fifth column (zero‑based index 4) and delete attached cells.
                        table.Columns.RemoveAt(4, true);

                        // Recalculate total width of remaining columns.
                        double totalWidth = 0;
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            totalWidth += table.Columns[i].Width;
                        }

                        // Distribute width equally among remaining columns.
                        double newWidth = totalWidth / table.Columns.Count;
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            table.Columns[i].Width = newWidth;
                        }
                    }

                    // Save the modified presentation.
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format.
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format.
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors).
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
