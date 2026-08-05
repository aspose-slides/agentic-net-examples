// -----------------------------------------------------------------------------
// Example: Export a PPTX presentation containing a pie chart with callout data labels to SVG using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add a pie chart with
// data labels displayed as callouts, save the presentation as PPTX, and then
// export the first slide to an SVG file while preserving text as vectors using
// Aspose.Slides for .NET. The example is a self‑contained console application that
// can be used as a reference for automating chart callout export scenarios.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, SVG, Export, Chart, Pie Chart,
// Data Labels, Callouts, Vector Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate PPTX files with charts that include callout data labels.
// - Convert slides containing chart callouts to high‑quality SVG for web or
//   documentation purposes.
// - Build .NET utilities for batch processing of PowerPoint charts and SVG
//   export.
// - Integrate chart callout rendering into automated reporting pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string presentationPath = "ChartCallout.pptx";
            string svgPath = "ChartCallout.svg";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a Pie chart
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                // Enable data labels as callouts
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Save the presentation
                presentation.Save(presentationPath, SaveFormat.Pptx);

                // Export the first slide to SVG with vector fidelity
                using (FileStream svgStream = File.Create(svgPath))
                {
                    SVGOptions svgOptions = new SVGOptions();
                    svgOptions.VectorizeText = true; // Preserve text as vectors
                    slide.WriteAsSvg(svgStream, svgOptions);
                }

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
