using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve the embedded fonts collection
        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // List each embedded font name
        foreach (IFontData font in embeddedFonts)
        {
            Console.WriteLine(font.FontName);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}