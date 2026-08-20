// -----------------------------------------------------------------------------
// Example: Align paragraphs center first row table using C#
//
// Description:
// Demonstrates how to align the paragraphs in the first row of a table to the
// center using C# and Aspose.Slides for .NET. The example loads an existing
// presentation, accesses the first table on the first slide, applies a
// centered paragraph format to all cells in the first row, and saves the
// modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Paragraph Alignment,
// Center Alignment, First Row, Presentation Processing, Office Automation
//
// Use Cases:
// - Center-align text in the first row of tables within PowerPoint slides.
// - Automate formatting of table content in bulk PPTX files.
// - Build .NET utilities for consistent presentation styling.
// - Prepare presentations for publishing with standardized table layouts.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableParagraphAlignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape as a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Create a paragraph format with center alignment
                Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
                paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                // Apply the paragraph format to all cells in the first row
                table.Rows[0].SetTextFormat(paragraphFormat);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: The presentation format may not be supported.
            }
        }
    }
}
