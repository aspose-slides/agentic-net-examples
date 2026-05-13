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