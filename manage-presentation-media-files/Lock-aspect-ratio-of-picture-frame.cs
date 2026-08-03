// -----------------------------------------------------------------------------
// Example: Lock aspect ratio of picture frame using C#
//
// Description:
// Demonstrates how to lock the aspect ratio of a picture frame using C# and
// Aspose.Slides for .NET. The example loads an existing presentation, inserts
// an image as a picture frame, locks its aspect ratio to prevent distortion
// during resizing, and saves the modified presentation. This pattern can be
// used to automate PPTX workflows, enforce visual consistency, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Lock, Aspect, Ratio, Picture,
// Frame, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate locking aspect ratio of picture frames in presentations.
// - Build C# tools for consistent image handling in PowerPoint files.
// - Generate or transform PPTX files while preserving image proportions.
// - Validate presentation layouts before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LockAspectRatioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string presentationPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";
            // Image to insert into picture frame
            string imagePath = "image.jpg";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Load the image and add it as a picture frame
                    using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        IPPImage img = presentation.Images.AddImage(imgStream);
                        IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50f, 50f, 200f, 200f, img);

                        // Lock the aspect ratio to prevent distortion during resizing
                        pictureFrame.ShapeLock.AspectRatioLocked = true;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or other errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
