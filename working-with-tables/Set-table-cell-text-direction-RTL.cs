// -----------------------------------------------------------------------------
// Example: Set table cell text direction RTL using C#
//
// Description:
// Demonstrates how to set table cell text direction RTL using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Cell, Text, Direction, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set table cell text direction RTL.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load existing presentation if it exists, otherwise create a new one
                if (File.Exists(inputPath))
                {
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        ProcessPresentation(presentation, outputPath);
                    }
                }
                else
                {
                    using (Presentation presentation = new Presentation())
                    {
                        ProcessPresentation(presentation, outputPath);
                    }
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported: PPTX
                Console.WriteLine("The presentation file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported: PPT
                Console.WriteLine("The presentation file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void ProcessPresentation(Presentation presentation, string outputPath)
        {
            // Access the first slide (creates one if the presentation is new)
            ISlide slide = presentation.Slides[0];

            // Define column widths and row heights for the table
            double[] columnWidths = new double[] { 150, 150, 150 };
            double[] rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Set text in the first cell (right‑to‑left language example)
            ICell cell = table[0, 0];
            cell.TextFrame.Text = "مرحبا بالعالم";

            // Set the table's reading order to right‑to‑left
            table.RightToLeft = true;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
