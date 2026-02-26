using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create HTML export options
                HtmlOptions htmlOptions = new HtmlOptions();

                // Create a formatting controller that embeds all fonts
                EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController();

                // Assign a custom HTML formatter that uses the font embedding controller
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController);

                // Save the presentation as HTML with embedded original fonts
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            }
        }
    }
}