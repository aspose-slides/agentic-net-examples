using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            var presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions);
            var slide = presentation.Slides[0];
            var autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;

            if (autoShape != null && autoShape.TextFrame != null)
            {
                var textFrame = autoShape.TextFrame;
                var newParagraph = new Aspose.Slides.Paragraph();
                newParagraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                textFrame.Paragraphs.Add(newParagraph);
            }

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}