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
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide and its master layout
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                Aspose.Slides.IMasterSlide masterSlide = firstSlide.LayoutSlide.MasterSlide;

                // Load image data from file
                byte[] imageBytes = File.ReadAllBytes("image.png");

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

                // Insert the picture into the master slide
                masterSlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 10, 10, 100, 100, image);

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}