using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the image file (BLOB source)
                string imagePath = "image.jpg";

                // Read the image into a byte array
                byte[] imageData = File.ReadAllBytes(imagePath);

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add the image to the presentation from a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        IPPImage img = pres.Images.AddImage(ms, LoadingStreamBehavior.KeepLocked);
                        // Insert the image onto the first slide as a picture frame
                        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);
                    }

                    // Save the presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}