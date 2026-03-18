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
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 400, 200);
            Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("First line of text.\nSecond line of text.\nThird line of text.");
            textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
            // Apply hanging indent (negative first line indent)
            paragraph.ParagraphFormat.Indent = -30f;
            // Set left margin for subsequent lines
            paragraph.ParagraphFormat.MarginLeft = 30f;
            presentation.Save("HangingIndent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}