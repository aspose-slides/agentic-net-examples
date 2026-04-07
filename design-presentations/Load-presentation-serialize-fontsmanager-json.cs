using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the presentation and custom fonts
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string fontPath1 = "fonts/CustomFont1.ttf";
        string fontPath2 = "fonts/CustomFont2.ttf";

        // Verify that the required files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found: " + inputPath);
            return;
        }
        if (!File.Exists(fontPath1) || !File.Exists(fontPath2))
        {
            Console.WriteLine("One or more custom font files not found.");
            return;
        }

        try
        {
            // Load custom font data into memory
            byte[] fontData1 = File.ReadAllBytes(fontPath1);
            byte[] fontData2 = File.ReadAllBytes(fontPath2);

            // Configure load options with custom font sources
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "fonts" };
            loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { fontData1, fontData2 };

            // Load the presentation using the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Retrieve fonts used in the presentation
            IFontData[] fonts = presentation.FontsManager.GetFonts();

            // Prepare a simple serializable structure for logging
            System.Collections.Generic.List<object> fontInfo = new System.Collections.Generic.List<object>();
            foreach (IFontData font in fonts)
            {
                fontInfo.Add(new { FontName = font.FontName });
            }

            // Serialize the FontsManager configuration to JSON
            string json = JsonSerializer.Serialize(fontInfo, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine("FontsManager configuration:");
            Console.WriteLine(json);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}