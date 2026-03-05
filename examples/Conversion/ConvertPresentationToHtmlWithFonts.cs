using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesHtmlConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output HTML file path
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Embed all fonts that are not already embedded
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool isEmbedded = false;
                foreach (Aspose.Slides.IFontData embeddedFont in embeddedFonts)
                {
                    if (embeddedFont.Equals(font))
                    {
                        isEmbedded = true;
                        break;
                    }
                }

                if (!isEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Set HTML export options (default linking behavior for fonts)
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}