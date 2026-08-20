// -----------------------------------------------------------------------------
// Example: Update PPTX modify cell at second slide using C#
//
// Description:
// Demonstrates how to update a PPTX file by modifying the text of a specific
// cell in the first table on the second slide using C# and Aspose.Slides for .NET.
// The example loads a presentation, locates the target cell, updates its text,
// and saves the result as a new PPTX file. This pattern can be used to automate
// table content updates in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Modify, Cell, Table,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate updating specific table cells in PowerPoint slides.
// - Build C# utilities for batch processing of PPTX files.
// - Integrate table content manipulation into .NET applications.
// - Validate and transform presentation data before distribution.
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
            // Path to the input PPTX file
            string inputPath = "input.pptx";
            // Path to the output PPTX file
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is a second slide (index 1)
                    if (presentation.Slides.Count < 2)
                    {
                        Console.WriteLine("The presentation does not contain a second slide.");
                        return;
                    }

                    // Get the second slide
                    ISlide secondSlide = presentation.Slides[1];

                    // Find the first table on the slide
                    ITable table = null;
                    foreach (IShape shape in secondSlide.Shapes)
                    {
                        table = shape as ITable;
                        if (table != null)
                            break;
                    }

                    if (table == null)
                    {
                        Console.WriteLine("No table found on the second slide.");
                        return;
                    }

                    // Row index 1 (second row), column index 2 (third column)
                    int targetRow = 1;
                    int targetColumn = 2;

                    // Verify that the requested cell exists
                    if (targetRow >= table.Rows.Count || targetColumn >= table.Columns.Count)
                    {
                        Console.WriteLine("Specified cell is out of range.");
                        return;
                    }

                    // Retrieve the cell using the ICell interface
                    ICell cell = table[targetColumn, targetRow];

                    // Modify the cell text
                    cell.TextFrame.Text = "Updated Text";

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
