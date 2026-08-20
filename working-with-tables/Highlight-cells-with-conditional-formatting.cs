// -----------------------------------------------------------------------------
// Example: Highlight cells with conditional formatting using C#
//
// Description:
// Demonstrates how to apply conditional formatting to table cells in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example highlights cells
// that contain a specific keyword by changing their background color. This pattern
// can be used to automate visual emphasis in PPTX files, generate reports, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Highlight, Cells, Conditional,
// Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically highlight important rows or values in tables.
// - Build C# tools for conditional visual styling of PowerPoint presentations.
// - Generate or transform PPTX files with data-driven formatting in .NET apps.
// - Validate and preview presentation content before publishing.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HighlightConditionalFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!System.IO.File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Process only table shapes
                            if (shape is ITable table)
                            {
                                // Iterate through rows and columns of the table
                                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                                {
                                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                                    {
                                        ICell cell = table[rowIndex, colIndex];
                                        if (cell?.TextFrame != null)
                                        {
                                            string cellText = cell.TextFrame.Text?.Trim();

                                            // Conditional formatting: highlight cells containing the word "Critical"
                                            if (!string.IsNullOrEmpty(cellText) &&
                                                cellText.Contains("Critical", StringComparison.OrdinalIgnoreCase))
                                            {
                                                // Apply solid light red fill to the cell
                                                cell.FillFormat.FillType = FillType.Solid;
                                                cell.FillFormat.SolidFillColor.Color = Color.LightCoral;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine($"Presentation saved to {outputPath}");
            }
            catch (Exception ex)
            {
                // Handle processing errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
