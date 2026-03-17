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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Path to the EMF image file to be used as a heading
            string emfPath = "heading.emf";

            // Load the EMF image and add it to the presentation
            using (FileStream emfStream = new FileStream(emfPath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage emfImage = presentation.Images.AddImage(emfStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Define position (X, Y) and size (Width, Height) for the heading image
                float x = 50f;
                float y = 20f;
                float width = 600f;
                float height = 100f;

                // Insert the EMF image as a picture frame on the slide
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, x, y, width, height, emfImage);
            }

            // Save the presentation to a PPTX file
            presentation.Save("HeadingPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}