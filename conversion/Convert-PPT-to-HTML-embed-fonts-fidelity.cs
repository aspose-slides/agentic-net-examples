using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.html";

                using (Presentation pres = new Presentation(inputPath))
                {
                    HtmlOptions htmlOptions = new HtmlOptions();
                    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController();
                    HtmlFormatter customFormatter = HtmlFormatter.CreateCustomFormatter(fontController);
                    htmlOptions.HtmlFormatter = customFormatter;

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}