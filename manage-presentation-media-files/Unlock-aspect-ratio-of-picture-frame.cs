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