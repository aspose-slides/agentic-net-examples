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
            var presentation = new Aspose.Slides.Presentation();

            // Get reference to the first slide
            var slide = presentation.Slides[0];

            // Embed an image from file
            var imagePath = "example.jpg";
            if (File.Exists(imagePath))
            {
                var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                var image = presentation.Images.AddImage(imageStream);
                // Add picture frame to the slide
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, image);
                imageStream.Close();
            }

            // Embed HTML content as a new slide
            var htmlContent = "<h1>Welcome</h1><p>This is an embedded HTML slide.</p>";
            presentation.Slides.AddFromHtml(htmlContent);

            // Save the presentation
            presentation.Save("EmbeddedContent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}