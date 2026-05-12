using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Prepare fallback rules collection
                FontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                // Example rule: Unicode range for Cyrillic (0x0400-0x04FF) fallback to Arial
                fallbackRules.Add(new FontFallBackRule(0x0400, 0x04FF, "Arial"));
                // Assign the collection to the FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation after assigning fallback rules
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}