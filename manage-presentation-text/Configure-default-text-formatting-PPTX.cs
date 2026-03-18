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

            using (var presentation = new Aspose.Slides.Presentation(loadOptions))
            {
                var slide = presentation.Slides[0];
                var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("Sample text");

                var saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.DefaultRegularFont = "Calibri";

                presentation.Save("DefaultTextStylePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}