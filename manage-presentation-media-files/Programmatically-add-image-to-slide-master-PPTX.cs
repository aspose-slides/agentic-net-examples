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
            using (Presentation presentation = new Presentation())
            {
                // Get the first master slide
                IMasterSlide masterSlide = presentation.Masters[0];

                // Load image bytes from file
                byte[] imageBytes = File.ReadAllBytes("image.png");

                // Add image to the presentation's image collection
                IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add picture frame to the master slide
                masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}