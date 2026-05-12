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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Add a fallback rule for Arabic script (Unicode range 0x0600–0x06FF) using a suitable font
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0600, 0x06FF, "Arial"));

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        // Handle unsupported file format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}