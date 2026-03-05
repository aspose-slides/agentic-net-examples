using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportParagraphsToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";

            // Output HTML file and CSS file
            string outputHtmlPath = "output.html";
            string cssFilePath = "styles.css";

            // CSS content (optional styling)
            string cssContent = "body { font-family: Arial; }";

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputHtmlPath);
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Write CSS file
            File.WriteAllText(cssFilePath, cssContent);

            // Configure HTML export options with a slide‑show formatter
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateSlideShowFormatter(cssFilePath, true);

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Export the presentation (including paragraph texts) to a single HTML file
            presentation.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}