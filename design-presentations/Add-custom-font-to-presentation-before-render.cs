using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var dataDir = "C:\\Fonts\\";
            var folders = new string[] { dataDir };
            Aspose.Slides.FontsLoader.LoadExternalFonts(folders);

            var presentationPath = dataDir + "Template.pptx";
            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                var allFonts = presentation.FontsManager.GetFonts();
                var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                foreach (var font in allFonts)
                {
                    var isEmbedded = false;
                    foreach (var ef in embeddedFonts)
                    {
                        if (ef.Equals(font))
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

                presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}