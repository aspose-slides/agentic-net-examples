using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEmfImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Path to the EMF image file
            string emfPath = "heading.emf";

            // Add the EMF image to the presentation's image collection
            Aspose.Slides.IPPImage emfImage;
            using (FileStream emfStream = new FileStream(emfPath, FileMode.Open, FileAccess.Read))
            {
                emfImage = presentation.Images.AddImage(emfStream);
            }

            // Insert the EMF image as a picture frame on the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50, 50, 400, 100, emfImage);

            // Save the presentation
            presentation.Save("PresentationWithEmf.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}