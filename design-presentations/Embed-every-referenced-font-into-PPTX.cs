using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get all fonts used in the presentation
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

            // Get fonts already embedded in the presentation
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Embed each font that is not already embedded
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
                    // Embed the font with all characters
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}