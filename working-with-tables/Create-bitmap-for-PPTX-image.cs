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
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Instantiate a bitmap (IImage) from the slide with full scale
                IImage bitmapImage = slide.GetImage(1f, 1f);

                // Add the bitmap image to the presentation's image collection
                IPPImage addedImage = pres.Images.AddImage(bitmapImage);

                // Insert the image into the slide as a picture frame
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 300, addedImage);

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}