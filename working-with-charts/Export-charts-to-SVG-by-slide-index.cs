// -----------------------------------------------------------------------------
// Example: Export Charts from PowerPoint Slides to Individual SVG Files Using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through each slide, extracts
// chart shapes, and writes each chart as a separate SVG file named by slide and chart
// index. The original presentation is saved unchanged. It demonstrates chart extraction
// for reporting, analytics, or web publishing using Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart export, SVG, slide index
//
// Use Cases:
// - Automate extraction of charts from presentations for inclusion in web pages.
// - Generate SVG assets for data visualization pipelines.
// - Create slide‑by‑slide chart inventories for compliance auditing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesChartExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path (modify as needed)
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: The file '" + inputPath + "' does not exist.");
                return;
            }

            // Verify supported file format (only PPTX is handled in this example)
            if (!inputPath.EndsWith(".pptx", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Error: Unsupported file format. Only PPTX files are supported.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    int chartCounter = 0;

                    // Iterate through shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Identify chart shapes
                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;
                            chartCounter++;

                            // Build SVG file name: slide{slideIndex}_chart{chartIndex}.svg
                            string svgFileName = string.Format(
                                "slide{0}_chart{1}.svg",
                                slideIndex + 1,
                                chartCounter);

                            // Export the chart as SVG
                            using (FileStream svgStream = new FileStream(
                                svgFileName,
                                FileMode.Create,
                                FileAccess.Write))
                            {
                                chart.WriteAsSvg(svgStream);
                            }

                            Console.WriteLine("Exported chart to: " + svgFileName);
                        }
                    }
                }

                // Save the presentation unchanged (optional: could save to a new file)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Processing completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., file access, Aspose.Slides runtime issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
