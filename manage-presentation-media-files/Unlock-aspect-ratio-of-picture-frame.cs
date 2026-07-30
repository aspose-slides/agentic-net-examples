// -----------------------------------------------------------------------------
// Example: Unlock aspect ratio of picture frame using C#
//
// Description:
// Demonstrates how to unlock the aspect ratio of a picture frame in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an existing
// PPTX file, accesses the first picture frame on the first slide, disables the
// aspect‑ratio lock, and saves the modified presentation. This pattern can be
// used in console applications or integrated into larger .NET solutions for
// presentation processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Unlock, Aspect Ratio, Picture Frame,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically unlock picture frame aspect ratio for custom resizing.
// - Build tools that modify slide content before publishing.
// - Automate batch processing of presentations to adjust image dimensions.
// - Validate and prepare PPTX files for downstream workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UnlockPictureAspectRatio
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

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Get the first shape as a picture frame
            IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;
            if (pictureFrame != null)
            {
                // Unlock aspect ratio to allow independent width and height adjustments
                pictureFrame.PictureFrameLock.AspectRatioLocked = false;
            }
            else
            {
                Console.WriteLine("No picture frame found on the first slide.");
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
