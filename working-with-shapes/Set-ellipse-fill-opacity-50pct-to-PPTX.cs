// -----------------------------------------------------------------------------
// Example: Set ellipse fill opacity 50pct to PPTX using C#
//
// Description:
// Demonstrates how to set ellipse fill opacity to 50% in a PPTX file using C#
// and Aspose.Slides for .NET. The example loads an existing presentation,
// iterates through all slides and shapes, identifies ellipse shapes, and
// adjusts their solid fill opacity to 50% when the fill is currently
// transparent. It then saves the modified presentation. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Fill, Opacity, 50Pct,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting ellipse fill opacity to 50% in PPTX files.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetEllipseFillOpacity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate over all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate over all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Cast to IAutoShape to access ShapeType
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                        {
                            // Get the fill format (read‑only property, but its members are writable)
                            IFillFormat fillFormat = autoShape.FillFormat;
                            if (fillFormat != null && fillFormat.FillType == FillType.Solid)
                            {
                                // Retrieve the current solid fill color
                                Color currentColor = fillFormat.SolidFillColor.Color;

                                // Check if the fill is transparent (alpha less than 255)
                                if (currentColor.A < 255)
                                {
                                    // Set opacity to 50% (alpha = 128)
                                    Color newColor = Color.FromArgb(128, currentColor.R, currentColor.G, currentColor.B);
                                    fillFormat.SolidFillColor.Color = newColor;
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
