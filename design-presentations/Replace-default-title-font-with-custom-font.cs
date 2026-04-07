using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output presentation and custom fonts folder
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string fontsFolder = "CustomFonts";

        // Verify that the input presentation file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found.");
            return;
        }

        // Verify that the custom fonts folder exists
        if (!Directory.Exists(fontsFolder))
        {
            Console.WriteLine("Custom fonts folder not found.");
            return;
        }

        try
        {
            // Load custom fonts from the specified folder
            string[] fontFolders = new string[] { fontsFolder };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Define source (default title font) and destination (custom font) font data
            IFontData sourceFont = new FontData("Arial"); // replace with actual default title font if different
            IFontData destFont = new FontData("MyCustomFont"); // replace with the exact name of the custom font file (without extension)

            // Replace the default title font with the custom font across the entire presentation
            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();

            // Clear the loaded custom fonts from cache
            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}