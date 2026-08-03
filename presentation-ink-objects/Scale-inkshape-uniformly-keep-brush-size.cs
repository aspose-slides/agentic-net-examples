// -----------------------------------------------------------------------------
// Example: Scale inkshape uniformly keep brush size using C#
//
// Description:
// Demonstrates how to uniformly scale an Ink shape in a PowerPoint presentation
// while preserving the original brush size using Aspose.Slides for .NET. The
// example loads a PPTX file, locates the first Ink shape on the first slide,
// applies a scaling factor to its position and dimensions, and saves the
// modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink shape, Scaling, Uniform,
// Brush size, Presentation processing, Office automation
//
// Use Cases:
// - Scale Ink shapes in existing presentations without altering stroke thickness.
// - Automate batch processing of PPTX files to adjust Ink object dimensions.
// - Integrate Ink shape manipulation into .NET applications for custom PPTX workflows.
// - Preserve visual consistency of handwritten annotations while resizing slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace InkScalingExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the first slide contains the Ink shape
                    ISlide slide = presentation.Slides[0];

                    // Find the first Ink shape on the slide
                    Ink inkShape = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            break;
                        }
                    }

                    if (inkShape == null)
                    {
                        Console.WriteLine("No Ink shape found on the first slide.");
                    }
                    else
                    {
                        // Uniform scaling factor
                        float scaleFactor = 2.0f;

                        // Apply scaling to position and size while preserving brush size
                        inkShape.X *= scaleFactor;
                        inkShape.Y *= scaleFactor;
                        inkShape.Width *= scaleFactor;
                        inkShape.Height *= scaleFactor;

                        // Brush size remains unchanged; no modification needed
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., loading errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
