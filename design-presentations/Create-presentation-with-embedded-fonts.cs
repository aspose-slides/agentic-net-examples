using System;
using System.Linq;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "Fonts.pptx";
            var outputPath = "AddEmbeddedFont_out.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var allFonts = presentation.FontsManager.GetFonts();
                var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                foreach (var font in allFonts)
                {
                    if (!embeddedFonts.Contains(font))
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}