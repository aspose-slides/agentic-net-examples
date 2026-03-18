using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add a text frame and set text
                autoShape.AddTextFrame("");
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

                // Set hyperlink on the text portion
                Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

                // Save the presentation
                presentation.Save("HyperlinkedTextBox.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}