using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load custom font from file and register it
            var fontPath = "customfont.ttf";
            var fontBytes = File.ReadAllBytes(fontPath);
            FontsLoader.LoadExternalFont(fontBytes);

            // Create a new presentation
            using (var presentation = new Presentation())
            {
                // Embed all fonts used in the presentation
                var allFonts = presentation.FontsManager.GetFonts();
                var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                foreach (var font in allFonts)
                {
                    if (Array.IndexOf(embeddedFonts, font) < 0)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with embedded fonts
                presentation.Save("EmbeddedFontPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}