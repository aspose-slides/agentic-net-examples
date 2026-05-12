using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Embed all custom fonts that are not already embedded
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool isEmbedded = false;
                foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                {
                    if (ef.Equals(font))
                    {
                        isEmbedded = true;
                        break;
                    }
                }
                if (!isEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save the presentation to XPS format with default options
            Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // If the exception is due to an unsupported format, note it
            // (In a real scenario, you would check the exception type or message)
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported
        }
    }
}