using System;

class Program
{
    static void Main()
    {
        // Path to the folder that contains the TrueType font files
        string fontFolder = "C:\\Fonts";

        // Load external fonts from the specified folder before creating any presentation objects
        string[] fontFolders = new string[] { fontFolder };
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation (contains one empty slide by default)
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Save the presentation to a file
            presentation.Save("PresentationWithCustomFont.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Clear the loaded font cache
        Aspose.Slides.FontsLoader.ClearCache();
    }
}