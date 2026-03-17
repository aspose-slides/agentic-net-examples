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
            string outputPath = "output_embedded.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;

                Aspose.Slides.IFontData[] allFonts = fontsManager.GetFonts();
                Aspose.Slides.IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool alreadyEmbedded = false;
                    foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
                    {
                        if (embedded.Equals(font))
                        {
                            alreadyEmbedded = true;
                            break;
                        }
                    }

                    if (!alreadyEmbedded)
                    {
                        fontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
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