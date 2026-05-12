using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output_embedded.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            IFontData[] allFonts = presentation.FontsManager.GetFonts();
            IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (IFontData font in allFonts)
            {
                bool alreadyEmbedded = false;
                foreach (IFontData embedded in embeddedFonts)
                {
                    if (embedded.FontName == font.FontName)
                    {
                        alreadyEmbedded = true;
                        break;
                    }
                }

                if (!alreadyEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            // If format not supported, comment that format not supported.
        }
    }
}