using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageIntoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputImagePath = "image.png";
            string outputPresentationPath = "output.pptx";

            // Check if the input image file exists
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine("Input image file does not exist: " + inputImagePath);
                return;
            }

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add image to the presentation's image collection
                    byte[] imageData = File.ReadAllBytes(inputImagePath);
                    IPPImage img = pres.Images.AddImage(imageData);

                    // Get the first master slide
                    IMasterSlide masterSlide = pres.Masters[0];

                    // Insert the image into the master slide so all subsequent slides inherit it
                    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 200, 200, img);

                    // Save the presentation
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}