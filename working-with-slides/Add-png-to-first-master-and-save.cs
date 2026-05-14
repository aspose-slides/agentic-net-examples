using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputImagePath = "highres.png";
        string outputPath = "output.pptx";

        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add the PNG image to the presentation's image collection
                byte[] imageData = File.ReadAllBytes(inputImagePath);
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageData);

                // Get the first master slide
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Add the image as a picture frame covering the entire master slide
                masterSlide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    image);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}