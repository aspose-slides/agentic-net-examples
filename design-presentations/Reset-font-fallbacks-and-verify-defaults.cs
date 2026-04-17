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

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Clear all fallback font rules by assigning an empty collection
            Aspose.Slides.IFontFallBackRulesCollection emptyRules = new Aspose.Slides.FontFallBackRulesCollection();
            pres.FontsManager.FontFallBackRulesCollection = emptyRules;

            // Save the presentation to confirm default fonts are applied
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}