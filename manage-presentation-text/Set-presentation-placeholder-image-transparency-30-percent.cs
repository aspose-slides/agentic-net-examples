// -----------------------------------------------------------------------------
// Example: Set presentation placeholder image transparency 30 percent using C#
//
// Description:
// Demonstrates how to set a 30 percent transparency on placeholder picture
// frames within a PowerPoint presentation using Aspose.Slides for .NET. The
// example loads an existing PPTX file, iterates through all slides and shapes,
// identifies placeholder picture frames, applies an AlphaModulateFixed effect
// to achieve the desired transparency, and saves the modified presentation.
// This pattern can be used in console applications or integrated into larger
// .NET solutions for automated PPTX processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Presentation, Placeholder,
// Image, Transparency, AlphaModulateFixed, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting 30% transparency on placeholder images in PPTX files.
// - Build C# utilities for batch processing of PowerPoint presentations.
// - Integrate image transparency adjustments into .NET applications.
// - Validate and transform presentation content before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Process only placeholder picture frames
                            if (shape.Placeholder != null && shape is Aspose.Slides.IPictureFrame)
                            {
                                Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;

                                // Apply 30% transparency using AlphaModulateFixed effect
                                pictureFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(30f);
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
