using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddHyperlinksToSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Example: add a few blank slides to demonstrate
                Aspose.Slides.ISlide slide1 = presentation.Slides[0];
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Define the URL to be used for all hyperlinks
                string url = "https://www.example.com";

                // Add hyperlink to each slide
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Add a rectangle shape that will hold the hyperlink
                    Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 50);

                    // Cast to IAutoShape to access text frame
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    autoShape.AddTextFrame("Visit Example.com");

                    // Set the external hyperlink on the shape
                    autoShape.HyperlinkClick = new Aspose.Slides.Hyperlink(url);
                }

                // Save the presentation
                presentation.Save("PresentationWithHyperlinks.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}