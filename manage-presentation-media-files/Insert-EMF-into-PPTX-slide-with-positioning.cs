using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Path to the EMF image file
                string emfPath = "vectorImage.emf";

                // Open the EMF file stream
                using (FileStream emfStream = new FileStream(emfPath, FileMode.Open, FileAccess.Read))
                {
                    // Add the EMF image to the presentation without rasterizing
                    IPPImage emfImage = pres.Images.AddImage(emfStream, LoadingStreamBehavior.KeepLocked);

                    // Insert the image as a picture frame on the first slide
                    // Parameters: shape type, X, Y, width, height, image
                    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 100, 100, 400, 300, emfImage);
                }

                // Save the presentation to a PPTX file
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}