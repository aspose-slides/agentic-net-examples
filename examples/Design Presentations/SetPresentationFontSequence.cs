using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle AutoShape with a text frame
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape.AddTextFrame("Sample Text");

        // Set font properties for the first paragraph and first portion
        shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24f;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Blue

        // Save the presentation
        pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}