using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";
            string cssUrl = "style.css";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
                options.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateSlideShowFormatter(cssUrl, true);
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}