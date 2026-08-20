// -----------------------------------------------------------------------------
// Example: Report table rows columns count per slide using C#
//
// Description:
// Demonstrates how to report the number of rows and columns for each table 
// found on every slide of a PowerPoint presentation using C# and Aspose.Slides 
// for .NET. The example loads a presentation, iterates through its slides and 
// shapes, identifies tables, outputs their dimensions to the console, and 
// optionally saves the presentation to a new file. This pattern helps automate 
// PPTX analysis, validation, or integration into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Rows, Columns, 
// Presentation Processing, Office Automation, Slide Analysis
//
// Use Cases:
// - Generate a report of table dimensions across all slides in a presentation.
// - Build C# utilities for PowerPoint content inspection and validation.
// - Automate extraction of table metadata for downstream processing.
// - Integrate table analysis into larger .NET-based Office automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTableReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the presentation file path (use first argument or a default path)
            string presentationPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Get the current slide
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast the shape to a Table
                            Table table = slide.Shapes[shapeIndex] as Table;

                            // If the shape is a table, report its dimensions
                            if (table != null)
                            {
                                int rowCount = table.Rows.Count;
                                int columnCount = table.Columns.Count;
                                Console.WriteLine($"Slide {slideIndex + 1}, Table {shapeIndex + 1}: Rows = {rowCount}, Columns = {columnCount}");
                            }
                        }
                    }

                    // Save the presentation (optional – saves to a new file)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // The presentation file format is not supported
                Console.WriteLine("The presentation file format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // The presentation file format is not supported (PPT version)
                Console.WriteLine("The presentation file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
