// -----------------------------------------------------------------------------
// Example: Export all charts to a single PDF using C#
//
// Description:
// Demonstrates how to extract every chart from a PowerPoint presentation,
// copy each chart onto its own slide in a new presentation, and then save the
// resulting presentation as a single PDF file using Aspose.Slides for .NET.
// The example includes loading the source PPTX, iterating through slides and
// shapes, cloning chart objects, and handling unsupported format exceptions.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, PDF, Chart Export, Presentation Processing,
// Office Automation, .NET
//
// Use Cases:
// - Generate a PDF containing only the charts from a presentation.
// - Automate reporting workflows that require chart extraction.
// - Create lightweight PDF documents for review or distribution.
// - Integrate chart-to-PDF conversion into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ExportChartsToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "input.pptx";
            string outputPath = "charts.pdf";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePath);
                return;
            }

            // Load the source presentation
            using (Presentation sourcePres = new Presentation(sourcePath))
            {
                // Create a new presentation that will contain only the charts
                using (Presentation chartPres = new Presentation())
                {
                    // Use the first layout slide as a template for new slides
                    ILayoutSlide layout = chartPres.LayoutSlides[0];

                    // Iterate through all slides in the source presentation
                    foreach (ISlide srcSlide in sourcePres.Slides)
                    {
                        // Iterate through all shapes on the current slide
                        foreach (IShape shape in srcSlide.Shapes)
                        {
                            // Check if the shape is a chart
                            if (shape is IChart)
                            {
                                IChart chart = (IChart)shape;

                                // Add a new empty slide to the chart presentation
                                ISlide newSlide = chartPres.Slides.AddEmptySlide(layout);

                                // Clone the chart onto the new slide
                                newSlide.Shapes.AddClone(chart);
                            }
                        }
                    }

                    // Save the chart presentation as a single PDF file
                    try
                    {
                        chartPres.Save(outputPath, SaveFormat.Pdf);
                    }
                    catch (PptxUnsupportedFormatException)
                    {
                        // Format not supported
                        Console.WriteLine("The requested format is not supported.");
                    }
                }
            }
        }
    }
}
