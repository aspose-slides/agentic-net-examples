using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        try
        {
            // Load existing presentation if it exists; otherwise create a new one
            var pres = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation();

            // Define a fallback rule for Japanese characters (Unicode range 0x3040–0x30FF) using "MS Mincho"
            var rule = new FontFallBackRule(0x3040, 0x30FF, "MS Mincho");

            // Create a collection, add the rule, and assign it to the presentation's FontsManager
            var rules = new FontFallBackRulesCollection();
            rules.Add(rule);
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
        }
    }
}