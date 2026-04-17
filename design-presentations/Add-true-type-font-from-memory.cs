using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontEmbeddingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPresentationPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string trueTypeFontPath = "customfont.ttf";

            // Verify that the input presentation exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPresentationPath);
                return;
            }

            // Verify that the TrueType font file exists
            if (!File.Exists(trueTypeFontPath))
            {
                Console.WriteLine("TrueType font file does not exist: " + trueTypeFontPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPresentationPath);

                // Load the font data into memory
                byte[] fontData = File.ReadAllBytes(trueTypeFontPath);

                // Embed the font into the presentation (embed all characters)
                presentation.FontsManager.AddEmbeddedFont(fontData, EmbedFontCharacters.All);

                // Save the presentation with the embedded font
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully with embedded font.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The specified file format is not supported by Aspose.Slides.
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}