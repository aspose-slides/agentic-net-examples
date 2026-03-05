using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first master slide in the presentation
            Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];

            // Load image bytes from file and add the image to the presentation's image collection
            byte[] imageBytes = File.ReadAllBytes("image.png");
            Aspose.Slides.IPPImage image = pres.Images.AddImage(imageBytes);

            // Add the image to the master slide so it appears on all slides that use this master
            masterSlide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                10,    // X position
                10,    // Y position
                100,   // Width
                100,   // Height
                image);

            // Save the presentation to disk
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}