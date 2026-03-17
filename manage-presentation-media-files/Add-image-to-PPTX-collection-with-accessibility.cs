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
            try
            {
                // Path to the image file to be inserted
                string imagePath = "image.jpg";

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Open the image file as a stream
                    using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        // Add the image to the presentation's image collection
                        IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);

                        // Insert the image onto the first slide as a picture frame
                        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);
                    }

                    // Save the presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}