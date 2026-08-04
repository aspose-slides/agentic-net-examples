// -----------------------------------------------------------------------------
// Example: Apply chart style template to all charts using C#
//
// Description:
// Demonstrates how to apply chart style template to all charts using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Chart, Style, Template, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply chart style template to all charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ApplyChartStyle
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a chart
                            IChart chart = shape as IChart;
                            if (chart != null)
                            {
                                // Apply a predefined chart style to the chart
                                // Replace Style1 with the desired style identifier
                                chart.Style = Aspose.Slides.Charts.StyleType.Style1;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format or I/O errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
