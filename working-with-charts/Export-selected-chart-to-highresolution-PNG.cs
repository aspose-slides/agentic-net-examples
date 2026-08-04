// -----------------------------------------------------------------------------
// Example: Export selected chart to high‑resolution PNG using C#
//
// Description:
// Demonstrates how to locate the first chart on the first slide of a PowerPoint
// presentation and export it as a high‑resolution PNG image using Aspose.Slides for
// .NET. The example also saves the (potentially unchanged) presentation to a new
// file. This pattern is useful for automating chart extraction, creating image
// assets from PPTX files, or integrating PowerPoint chart processing into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Selected, Chart,
// High‑resolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of a specific chart as a high‑resolution PNG.
// - Build C# utilities for PowerPoint chart image generation.
// - Integrate chart export functionality into .NET services or desktop tools.
// - Validate and process PPTX files before publishing or further transformation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output presentation, and chart image
        string inputPath = "input.pptx";
        string outputPresentationPath = "output.pptx";
        string chartImagePath = "chart.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Find the first chart on the first slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
            }
            else
            {
                // Export the chart as a high‑resolution PNG image
                IImage chartImage = chart.GetImage();
                chartImage.Save(chartImagePath, ImageFormat.Png);
                chartImage.Dispose();
            }

            // Save the (potentially modified) presentation before exiting
            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
