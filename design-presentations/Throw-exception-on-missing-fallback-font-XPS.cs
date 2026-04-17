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
            Presentation pres = new Presentation(inputPath);

            // Create fallback font rules collection
            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
            // Example rule: map emoji Unicode range to a fallback font
            rules.Add(new FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji"));
            // Assign the rules to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Configure XPS save options (optional default regular font)
            XpsOptions options = new XpsOptions();
            options.DefaultRegularFont = "Arial";

            // Save the presentation to XPS format
            pres.Save(outputPath, SaveFormat.Xps, options);

            // Dispose the presentation
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle missing fallback font scenario with a descriptive message
            if (ex.Message.IndexOf("fallback", StringComparison.OrdinalIgnoreCase) >= 0 ||
                ex.Message.IndexOf("font", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("Error: Required fallback fonts are missing. " + ex.Message);
            }
            // Handle unsupported format exception
            else if (ex is NotSupportedException)
            {
                // Format not supported.
                Console.WriteLine("Error: The file format is not supported.");
            }
            else
            {
                // General exception handling
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}