// -----------------------------------------------------------------------------
// Example: Load PPTX slide and access chart using C#
//
// Description:
// Demonstrates how to load a PPTX file, retrieve a specific slide, and access
// a chart object on that slide using C# and Aspose.Slides for .NET. The example
// shows the essential steps for loading a presentation, locating a chart,
// reading its data range, and saving the modified presentation. This pattern
// helps developers automate PowerPoint chart processing, validate chart data,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Slide, Chart, Access, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading a PPTX slide and accessing its chart.
// - Build C# tools for PowerPoint chart analysis and manipulation.
// - Generate or transform PPTX files with chart data in .NET applications.
// - Validate chart contents before publishing or integration.
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
            // Define the directory and file names
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input PPTX file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the specified file
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Retrieve the target slide (first slide in this example)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Access the chart object on the slide (assumes the first shape is a chart)
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the selected slide.");
                }
                else
                {
                    // Example operation: get the chart data range
                    string range = (chart.ChartData as Aspose.Slides.Charts.ChartData).GetRange();
                    Console.WriteLine("Chart data range: " + range);
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported file format or loading issues
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, it can be noted here
            }
        }
    }
}
