// -----------------------------------------------------------------------------
// Example: Convert picture frame images to grayscale using C#
//
// Description:
// Demonstrates how to convert images within picture frames to grayscale using
// C# and Aspose.Slides for .NET. The example loads a PPTX file, applies a
// grayscale image transform to each picture frame, and saves the modified
// presentation. This pattern can be used to automate image processing in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Picture Frame, Image,
// Grayscale, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of picture frame images to grayscale in presentations.
// - Build C# utilities for batch image processing within PPTX files.
// - Integrate grayscale transformation into .NET PowerPoint workflows.
// - Prepare presentations for printing or visual consistency.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ConvertPictureFramesToGrayscale
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Process only picture frames
                        if (shape is IPictureFrame pictureFrame)
                        {
                            // Get the image transform collection and add a grayscale effect
                            IImageTransformOperationCollection imgTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
                            imgTransform.AddGrayScaleEffect();
                        }
                    }
                }

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
