using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEmfImagesToSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Path to the EMF image generated from an Excel sheet
            string emfFilePath = "excel_sheet.emf";

            // Open the EMF file as a stream
            FileStream emfStream = new FileStream(emfFilePath, FileMode.Open, FileAccess.Read);

            // Add the EMF image to the presentation's image collection
            Aspose.Slides.IPPImage emfImage = presentation.Images.AddImage(emfStream);

            // Close the stream as it is no longer needed
            emfStream.Close();

            // Add the EMF image to the slide as a picture frame
            slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f,  // Height
                emfImage);

            // Save the presentation in PPTX format
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}