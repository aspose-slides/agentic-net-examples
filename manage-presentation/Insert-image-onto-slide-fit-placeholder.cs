using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data";
            string imageFileName = "image.jpg";
            string imagePath = Path.Combine(dataDir, imageFileName);
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Load the image from file
                IImage img = Images.FromFile(imagePath);

                // Add image to the presentation's image collection
                IPPImage ppImg = pres.Images.AddImage(img);

                // Add picture frame to the first slide using the image dimensions
                IPictureFrame pf = pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    0,
                    0,
                    ppImg.Width,
                    ppImg.Height,
                    ppImg);

                // Calculate scaling factors to fit the slide size
                float scaleWidth = (float)pres.SlideSize.Size.Width / ppImg.Width;
                float scaleHeight = (float)pres.SlideSize.Size.Height / ppImg.Height;

                // Apply relative scaling to the picture frame
                pf.RelativeScaleWidth = scaleWidth;
                pf.RelativeScaleHeight = scaleHeight;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}