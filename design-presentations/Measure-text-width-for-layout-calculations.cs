using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions(LoadFormat.Auto);
            loadOptions.DefaultRegularFont = "Arial"; // set default sans‑serif font

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Sample text for measurement");

                // Example of retrieving font height; actual width measurement would require rendering APIs
                float fontHeight = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight;
                Console.WriteLine("Font height used: " + fontHeight);

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}