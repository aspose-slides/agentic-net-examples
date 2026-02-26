using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the array of embedded fonts
        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // List each embedded font name
        foreach (Aspose.Slides.IFontData font in embeddedFonts)
        {
            // The FontName property provides the name of the font
            Console.WriteLine(font.FontName);
        }

        // Save the presentation (even if unchanged) as required
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}