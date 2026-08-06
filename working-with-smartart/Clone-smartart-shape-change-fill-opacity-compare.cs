// -----------------------------------------------------------------------------
// Example: Clone smartart shape change fill opacity compare using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, modify its fill opacity, and
// export slide images for visual comparison using C# and Aspose.Slides for .NET.
// The example loads a presentation, clones the first SmartArt shape on the
// first slide, sets its fill to 50% opacity, saves before/after slide images,
// and writes the updated presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Fill Opacity,
// Image Export, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes and adjusting visual properties.
// - Generate before/after screenshots of slide modifications.
// - Build tools for PowerPoint presentation processing and validation.
// - Integrate SmartArt manipulation into .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string originalImagePath = "original.png";
            string clonedImagePath = "cloned.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Locate the first SmartArt shape on the slide
                    IShape smartArtShape = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is ISmartArt)
                        {
                            smartArtShape = shape;
                            break;
                        }
                    }

                    if (smartArtShape == null)
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                        return;
                    }

                    // Clone the SmartArt shape using the shape collection AddClone method
                    // Place the clone below the original shape
                    IShape clonedShape = slide.Shapes.AddClone(
                        smartArtShape,
                        smartArtShape.X,
                        smartArtShape.Y + smartArtShape.Height);

                    // Change fill opacity of the cloned SmartArt shape
                    // Set solid fill and adjust alpha (opacity) to 50%
                    clonedShape.FillFormat.FillType = FillType.Solid;
                    clonedShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
                    clonedShape.FillFormat.SolidFillColor.ColorTransform.Add(
                        ColorTransformOperation.MultiplyAlpha,
                        0.5f);

                    // Export original slide image for visual comparison
                    using (IImage originalImage = slide.GetImage())
                    {
                        originalImage.Save(originalImagePath, ImageFormat.Png);
                    }

                    // Export modified slide image for visual comparison
                    using (IImage clonedImage = slide.GetImage())
                    {
                        clonedImage.Save(clonedImagePath, ImageFormat.Png);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
