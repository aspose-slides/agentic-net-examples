using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RegisterUserFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the presentation and the user font folder
            string presentationPath = "input.pptx";
            string outputPath = "output.pptx";
            string fontsFolder = "UserFonts";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Verify that the font folder exists
            if (!Directory.Exists(fontsFolder))
            {
                Console.WriteLine("Fonts folder not found: " + fontsFolder);
                return;
            }

            try
            {
                // Register external fonts before loading the presentation
                string[] fontFolders = new string[] { fontsFolder };
                Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Embed any fonts that are used but not yet embedded
                    Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
                    Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    foreach (Aspose.Slides.IFontData font in allFonts)
                    {
                        bool alreadyEmbedded = false;
                        foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
                        {
                            if (embedded.FontName == font.FontName)
                            {
                                alreadyEmbedded = true;
                                break;
                            }
                        }

                        if (!alreadyEmbedded)
                        {
                            presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                // Clear the font cache after processing
                Aspose.Slides.FontsLoader.ClearCache();
            }
            catch (NotSupportedException)
            {
                // The file format is not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}