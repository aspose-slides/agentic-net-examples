using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string logPath = "fonts_log.txt";
        string fontsOutputDir = "ExtractedFonts";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get all fonts used in the presentation
            Aspose.Slides.IFontData[] fonts = presentation.FontsManager.GetFonts();

            // Ensure the fonts output directory exists
            if (!Directory.Exists(fontsOutputDir))
            {
                Directory.CreateDirectory(fontsOutputDir);
            }

            // Open log file for writing font file paths
            using (StreamWriter logWriter = new StreamWriter(logPath, false))
            {
                foreach (Aspose.Slides.IFontData font in fonts)
                {
                    // Retrieve font bytes (regular style)
                    byte[] fontBytes = presentation.FontsManager.GetFontBytes(font, Aspose.Slides.FontStyleType.Regular);

                    // Create a file path for the extracted font
                    string fontFilePath = Path.Combine(fontsOutputDir, font.FontName + ".ttf");

                    // Write the font bytes to the file
                    File.WriteAllBytes(fontFilePath, fontBytes);

                    // Log the font file path
                    logWriter.WriteLine(fontFilePath);
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported or other processing error
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}