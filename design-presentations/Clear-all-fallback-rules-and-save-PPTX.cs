using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";
        var outputPath = "output_cleaned.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            var pres = new Aspose.Slides.Presentation(inputPath);

            // Clear all font fallback rules
            var emptyRules = new Aspose.Slides.FontFallBackRulesCollection();
            pres.FontsManager.FontFallBackRulesCollection = emptyRules;

            // Save presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentation
            pres.Dispose();

            Console.WriteLine("Presentation saved successfully to " + outputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}