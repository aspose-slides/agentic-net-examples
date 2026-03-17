using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the custom font file
            string fontPath = "customfont.ttf";
            // Read font data into a byte array
            byte[] fontData = File.ReadAllBytes(fontPath);

            // Load the external font into Aspose.Slides font cache
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Embed the custom font into the presentation
            presentation.FontsManager.AddEmbeddedFont(fontData, Aspose.Slides.Export.EmbedFontCharacters.All);

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}