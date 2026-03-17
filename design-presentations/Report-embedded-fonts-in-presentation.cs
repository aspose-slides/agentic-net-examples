using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Retrieve embedded fonts
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                Console.WriteLine("Embedded fonts:");
                foreach (Aspose.Slides.IFontData font in embeddedFonts)
                {
                    // Display font name (additional characteristics can be accessed if needed)
                    string fontName = font.FontName;
                    Console.WriteLine("- " + fontName);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}