using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEmfImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the EMF image file
            string emfFilePath = "image.emf";

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load the EMF image into the presentation's image collection
                using (FileStream emfStream = new FileStream(emfFilePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage emfImage = presentation.Images.AddImage(emfStream);

                    // Add the EMF image to the slide as a picture frame
                    slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        50,    // X position
                        50,    // Y position
                        400,   // Width
                        300,   // Height
                        emfImage);
                }

                // Save the presentation to a PPTX file
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}