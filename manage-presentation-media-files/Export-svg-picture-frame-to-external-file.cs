// -----------------------------------------------------------------------------
// Example: Export svg picture frame to external file using C#
//
// Description:
// Demonstrates how to export an SVG picture frame from a PowerPoint slide to an
// external SVG file using C# and Aspose.Slides for .NET. The example loads a
// presentation, extracts the first shape (assumed to be an SVG picture frame),
// writes it to a standalone SVG file preserving vector data, and optionally
// saves the presentation back to PPTX format. This pattern is useful for
// automating PPTX workflows, extracting vector graphics, or integrating
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Picture, Frame,
// External, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SVG picture frames from PowerPoint presentations.
// - Build C# tools for processing and converting slide graphics to SVG.
// - Generate or transform PPTX files while preserving vector assets.
// - Validate and test presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPptxPath = Path.Combine(dataDir, "input.pptx");
            string outputSvgPath = Path.Combine(dataDir, "exported_shape.svg");
            string outputPptxPath = Path.Combine(dataDir, "saved_presentation.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input file not found: " + inputPptxPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptxPath))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Assume the first shape is the SVG picture frame
                    Aspose.Slides.IShape shape = slide.Shapes[0];

                    // Export the shape to an external SVG file, preserving vector paths
                    using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                    {
                        shape.WriteAsSvg(svgStream);
                    }

                    // Save the presentation before exiting (optional, demonstrates lifecycle rule)
                    pres.Save(outputPptxPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
