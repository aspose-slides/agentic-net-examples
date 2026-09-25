// -----------------------------------------------------------------------------
// Example: Add Rotated Picture Frame and Verify Bounding Box in PowerPoint
//
// Description:
// This console application demonstrates how to add a picture frame to a new
// PowerPoint presentation using Aspose.Slides for .NET, apply a custom rotation
// angle, calculate the resulting bounding box dimensions, and save the file.
// It validates image handling and geometric transformations for developers
// automating PPTX generation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, picture frame, rotation, bounding box
//
// Use Cases:
// - Automate insertion of rotated images into slide decks.
// - Validate layout calculations after applying transformations.
// - Generate reports with precise geometric metadata of slide elements.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace RotatedPictureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string imagePath = "input.jpg";
            string outputPath = "RotatedPicture.pptx";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Error: Image file not found at path: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Load the image into Aspose.Slides
                Aspose.Slides.IImage slideImage = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(slideImage);

                // Add a picture frame to the first slide
                Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f,               // X position
                    100f,               // Y position
                    pptImage.Width,     // Width of the picture
                    pptImage.Height,    // Height of the picture
                    pptImage);

                // Apply rotation (in degrees)
                pictureFrame.Rotation = 45f;

                // Calculate bounding box after rotation
                double angleRadians = pictureFrame.Rotation * Math.PI / 180.0;
                double originalWidth = pictureFrame.Width;
                double originalHeight = pictureFrame.Height;

                double boundingBoxWidth = Math.Abs(originalWidth * Math.Cos(angleRadians)) + Math.Abs(originalHeight * Math.Sin(angleRadians));
                double boundingBoxHeight = Math.Abs(originalWidth * Math.Sin(angleRadians)) + Math.Abs(originalHeight * Math.Cos(angleRadians));

                // Output bounding box dimensions
                Console.WriteLine("Original Width:  " + originalWidth);
                Console.WriteLine("Original Height: " + originalHeight);
                Console.WriteLine("Rotation Angle:  " + pictureFrame.Rotation + " degrees");
                Console.WriteLine("Bounding Box Width:  " + boundingBoxWidth);
                Console.WriteLine("Bounding Box Height: " + boundingBoxHeight);

                // Ensure output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
