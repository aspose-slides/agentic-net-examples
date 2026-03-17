using System;
using Aspose.Slides.Export;

namespace FontListing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;
                    Aspose.Slides.IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

                    Console.WriteLine("Embedded fonts:");
                    foreach (Aspose.Slides.IFontData font in embeddedFonts)
                    {
                        Console.WriteLine(font.FontName);
                    }

                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}