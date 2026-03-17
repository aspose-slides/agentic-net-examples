using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle shape
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 50);
                var autoShape = (IAutoShape)shape;

                // Add a text frame and set text
                autoShape.AddTextFrame("Click Here");
                var textFrame = autoShape.TextFrame;
                var portion = textFrame.Paragraphs[0].Portions[0];

                // Set an external hyperlink on the text portion
                var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Add an image and set a hyperlink on the picture frame
                var imageBytes = System.IO.File.ReadAllBytes("sample.png"); // Ensure the file exists
                var image = presentation.Images.AddImage(imageBytes);
                var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100, 200, 200, 150, image);
                pictureFrame.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

                // Save the presentation
                presentation.Save("HyperlinkedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}