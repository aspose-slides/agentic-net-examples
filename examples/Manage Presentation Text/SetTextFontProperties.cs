using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an AutoShape with some text
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Hello Aspose.Slides!");

        // Access the first paragraph and portion
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set font properties
        portion.PortionFormat.FontHeight = 24;
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Calibri");
        portion.PortionFormat.EastAsianFont = new Aspose.Slides.FontData("SimSun");
        portion.PortionFormat.ComplexScriptFont = new Aspose.Slides.FontData("Arial");

        // Save the presentation
        presentation.Save("ManagedFontProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}