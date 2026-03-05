using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add a TextFrame to the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(" ");

        // Access the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Create a new Portion
        Aspose.Slides.IPortion portion = new Aspose.Slides.Portion();

        // Set the text of the portion
        portion.Text = "Hello Aspose.Slides!";

        // Apply character formatting
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.FontHeight = 24f;
        portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.False;
        portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;

        // Add the portion to the paragraph
        paragraph.Portions.Add(portion);

        // Save the presentation
        presentation.Save("PortionFormatting_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}