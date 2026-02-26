using System;
using System.IO;

namespace DesignPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder containing custom fonts
            string fontsFolderPath = "CustomFonts";

            // Load custom fonts before creating any presentation objects
            Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontsFolderPath });

            // Input and output presentation files
            string inputPresentationPath = "InputPresentation.pptx";
            string outputPresentationPath = "OutputPresentation.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);

            // Get all fonts used in the presentation
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

            // Get fonts already embedded in the presentation
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Embed any missing fonts
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
                    // Embed the font with all characters
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            // Clear the loaded custom fonts from cache
            Aspose.Slides.FontsLoader.ClearCache();
        }
    }
}