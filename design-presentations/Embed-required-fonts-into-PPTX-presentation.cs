using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedFontsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_embedded.pptx";

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Retrieve all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Retrieve fonts that are already embedded
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed fonts that are not yet embedded
                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (Aspose.Slides.IFontData ef in embeddedFonts)
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

                // Save the presentation with embedded fonts
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}