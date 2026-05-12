using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Font folders and font files
        string fontFolder1 = "fonts";
        string fontFolder2 = "morefonts";
        string fontPath1 = "fonts/CustomFont1.ttf";
        string fontPath2 = "fonts/CustomFont2.ttf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load font data into memory
            byte[] fontData1 = File.ReadAllBytes(fontPath1);
            byte[] fontData2 = File.ReadAllBytes(fontPath2);

            // Configure load options with custom font sources
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DocumentLevelFontSources.FontFolders = new string[] { fontFolder1, fontFolder2 };
            loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { fontData1, fontData2 };

            // Load presentation with the specified load options
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Example operation: list fonts used in the presentation
                Aspose.Slides.IFontData[] fonts = presentation.FontsManager.GetFonts();
                foreach (Aspose.Slides.IFontData font in fonts)
                {
                    Console.WriteLine("Font: " + font.FontName);
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}