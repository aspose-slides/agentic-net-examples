using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the fallback rules collection
                IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                // Add a wildcard fallback rule for all Unicode characters, using Arial as fallback
                fallbackRules.Add(new FontFallBackRule(0x0000, 0xFFFF, new string[] { "Arial" }));

                // Save the presentation as PDF
                presentation.Save(outputPath, SaveFormat.Pdf);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}