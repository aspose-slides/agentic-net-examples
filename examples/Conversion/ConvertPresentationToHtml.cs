using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // No fonts to exclude from embedding
            string[] fontExclude = new string[0];

            // Create a controller that embeds all fonts
            Aspose.Slides.Export.EmbedAllFontsHtmlController embedController = new Aspose.Slides.Export.EmbedAllFontsHtmlController(fontExclude);

            // Set up HTML options with the custom formatter
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
            {
                HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Save the presentation as HTML with embedded fonts
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}