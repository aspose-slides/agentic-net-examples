using System;
using Aspose.Slides;
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

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Sample text with missing font");

            // Set font properties for the text portion
            Aspose.Slides.IPortion portion = textFrame.Paragraphs[0].Portions[0];
            portion.PortionFormat.FontHeight = 24f;
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("NonExistentFont");

            // Define fallback font using PptxOptions
            Aspose.Slides.Export.PptxOptions options = new Aspose.Slides.Export.PptxOptions();
            options.DefaultRegularFont = "Arial";

            // Save the presentation with fallback font settings
            presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}