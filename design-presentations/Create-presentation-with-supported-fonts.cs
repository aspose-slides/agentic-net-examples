using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);

            // Add text to the shape
            autoShape.AddTextFrame("Hello Aspose.Slides!");

            // Access the first portion of the first paragraph
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Set font properties using PortionFormat
            portion.PortionFormat.FontHeight = 24f;
            portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.False;

            // Save the presentation
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}