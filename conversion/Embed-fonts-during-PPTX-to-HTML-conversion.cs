using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.html";

            using (Presentation pres = new Presentation(inputPath))
            {
                var htmlOptions = new HtmlOptions();
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new EmbedAllFontsHtmlController());

                pres.Save(outputPath, SaveFormat.Html, htmlOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}