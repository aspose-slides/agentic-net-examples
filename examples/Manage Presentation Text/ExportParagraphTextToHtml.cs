using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentationPath = "input.pptx";
        var htmlPath = "output.html";

        using (var presentation = new Aspose.Slides.Presentation(presentationPath))
        {
            var slide = presentation.Slides[0];
            var shape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
            if (shape != null && shape.TextFrame != null)
            {
                var paragraphs = shape.TextFrame.Paragraphs;
                var options = new Aspose.Slides.Export.TextToHtmlConversionOptions();
                var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
                File.WriteAllText(htmlPath, html);
            }

            // Save the presentation before exiting
            presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}