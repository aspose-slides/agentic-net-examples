using System;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to the slide
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

                // Cast the shape to IAutoShape to work with text
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add an empty text frame
                autoShape.AddTextFrame("");

                // Access the text frame
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                // Set the display text
                textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

                // Get the hyperlink manager for the portion
                Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

                // Assign an external hyperlink to the text
                hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

                // Save the presentation
                presentation.Save("HyperlinkPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}