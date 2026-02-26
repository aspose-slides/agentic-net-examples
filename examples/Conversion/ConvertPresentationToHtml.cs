using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PowerPoint presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Embed all fonts that are used in the presentation but not yet embedded
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            for (int i = 0; i < allFonts.Length; i++)
            {
                Aspose.Slides.IFontData font = allFonts[i];
                bool isEmbedded = false;
                for (int j = 0; j < embeddedFonts.Length; j++)
                {
                    if (embeddedFonts[j].Equals(font))
                    {
                        isEmbedded = true;
                        break;
                    }
                }
                if (!isEmbedded)
                {
                    // Embed the font with all characters
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Set HTML export options (optional customizations can be added here)
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Save the presentation as HTML with embedded fonts
            presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}