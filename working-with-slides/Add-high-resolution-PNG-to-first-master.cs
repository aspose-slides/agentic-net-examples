using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputImagePath = "highres.png";
        string outputPresentationPath = "output.pptx";

        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist: " + inputImagePath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add image to the presentation's image collection
                byte[] imageData = File.ReadAllBytes(inputImagePath);
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageData);

                // Ensure there is at least one master slide
                if (presentation.Masters.Count == 0)
                {
                    Console.WriteLine("No master slides available.");
                    return;
                }

                // Get the first master slide
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Get slide dimensions
                float slideWidth = presentation.SlideSize.Size.Width;
                float slideHeight = presentation.SlideSize.Size.Height;

                // Add picture frame covering the entire master slide
                Aspose.Slides.IPictureFrame pictureFrame = masterSlide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0f,
                    0f,
                    slideWidth,
                    slideHeight,
                    image);

                // Save the presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}