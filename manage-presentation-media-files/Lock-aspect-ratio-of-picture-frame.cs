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