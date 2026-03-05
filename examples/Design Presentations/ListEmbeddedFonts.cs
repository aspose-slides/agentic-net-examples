using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Presentation presentation = new Presentation("input.pptx");

        // Retrieve the array of embedded fonts
        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // List each embedded font's name
        foreach (IFontData font in embeddedFonts)
        {
            Console.WriteLine(font.FontName);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}