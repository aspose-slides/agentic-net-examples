using System;

namespace AsposeSlidesHtmlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputFile = "input.pptx";
            string outputFile = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

            // List of fonts to exclude from embedding (preserve original fonts)
            string[] excludeList = new string[] { "Arial", "Times New Roman" };

            // Create a controller that embeds all fonts except those in the exclude list
            Aspose.Slides.Export.EmbedAllFontsHtmlController embedController = new Aspose.Slides.Export.EmbedAllFontsHtmlController(excludeList);

            // Set up HTML export options with the custom formatter
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
            {
                HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Save the presentation as HTML with embedded fonts
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}