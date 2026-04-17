using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            if (embeddedFonts != null && embeddedFonts.Length > 0)
            {
                foreach (Aspose.Slides.IFontData font in embeddedFonts)
                {
                    Console.WriteLine("Embedded Font: " + font.FontName);
                }
            }
            else
            {
                Console.WriteLine("No embedded fonts found.");
            }

            // Save presentation before exit
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}