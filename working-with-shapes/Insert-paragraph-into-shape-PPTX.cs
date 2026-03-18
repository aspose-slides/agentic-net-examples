using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Placeholder");
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];
            portion.Text = "Hello Aspose.Slides!";
            portion.PortionFormat.FontHeight = 24;
            portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}