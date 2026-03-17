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

            using (Presentation presentation = new Presentation(inputPath))
            {
                HtmlOptions options = new HtmlOptions();
                // Font embedding is disabled by default; no EmbedAllFontsHtmlController is assigned.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}