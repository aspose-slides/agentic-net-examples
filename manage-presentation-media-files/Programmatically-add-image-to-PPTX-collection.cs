using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the image file to be added
                string imagePath = "image.jpg";
                // Path where the resulting PPTX will be saved
                string outputPath = "output.pptx";

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add the image to the presentation's image collection
                    using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        IPPImage img = pres.Images.AddImage(imgStream, LoadingStreamBehavior.KeepLocked);
                        // Optionally place the image on the first slide
                        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, img.Width, img.Height, img);
                    }

                    // Save the presentation in PPTX format
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}