using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the input presentation, the TrueType font, and the output file
            string inputPresentationPath = "input.pptx";
            string trueTypeFontPath = "MyFont.ttf";
            string outputPresentationPath = "output.pptx";

            // Load the existing presentation
            using (Presentation presentation = new Presentation(inputPresentationPath))
            {
                // Read the TrueType font file into a byte array
                byte[] fontBytes = File.ReadAllBytes(trueTypeFontPath);

                // Embed the font into the presentation (embed all characters)
                presentation.FontsManager.AddEmbeddedFont(fontBytes, EmbedFontCharacters.All);

                // Save the presentation with the embedded font
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}