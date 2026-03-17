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
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            Aspose.Slides.ITextFrame textFrame = ((Aspose.Slides.IAutoShape)shape).AddTextFrame("Sample text with custom font");
            textFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("NonExistentFont");
            Aspose.Slides.Export.PptxOptions options = new Aspose.Slides.Export.PptxOptions();
            options.DefaultRegularFont = "Arial";
            presentation.Save("CustomFontSubstitution.pptx", Aspose.Slides.Export.SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}