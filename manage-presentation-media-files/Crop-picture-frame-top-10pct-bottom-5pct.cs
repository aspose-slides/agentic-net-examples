// -----------------------------------------------------------------------------
// Example: Crop picture frame top 10pct bottom 5pct using C#
//
// Description:
// Demonstrates how to crop a picture frame by removing 10% from the top and
// 5% from the bottom using C# and Aspose.Slides for .NET. The example loads a
// PPTX file, locates the first picture frame on the first slide, applies the
// crop settings, and saves the modified presentation. This pattern can be used
// to automate picture cropping in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Crop, Picture, Frame, 10Pct, 5Pct,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cropping of picture frames in PPTX presentations.
// - Build C# utilities for PowerPoint image manipulation.
// - Integrate picture cropping into .NET document processing pipelines.
// - Prepare presentations with consistent image margins before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CropPictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Find the first picture frame on the slide
                    IPictureFrame pictureFrame = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            break;
                        }
                    }

                    if (pictureFrame == null)
                    {
                        Console.WriteLine("No picture frame found on the first slide.");
                    }
                    else
                    {
                        // Crop 10% from the top and 5% from the bottom
                        pictureFrame.PictureFormat.CropTop = 0.10f;    // 10 percent
                        pictureFrame.PictureFormat.CropBottom = 0.05f; // 5 percent
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (including missing SlidesException type)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
