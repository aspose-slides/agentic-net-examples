using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide (a new presentation always contains one empty slide)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load image data from a file
                byte[] imageData = File.ReadAllBytes("inputImage.png");

                // Add the image to the presentation and obtain an IPPImage instance
                Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(imageData);

                // Insert a picture frame that covers the whole slide using the IPPImage
                slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0f,
                    0f,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    ippImage);

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}