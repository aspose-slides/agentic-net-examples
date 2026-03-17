using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the source and destination presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load the existing presentation
            pres = new Aspose.Slides.Presentation(inputPath);

            // Create a new collection of fallback rules
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add a rule for emoji characters to fall back to "Segoe UI Emoji"
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600u, 0x1F64Fu, "Segoe UI Emoji"));

            // Add a rule for CJK characters to fall back to "Microsoft YaHei"
            rules.Add(new Aspose.Slides.FontFallBackRule(0x4E00u, 0x9FFFu, "Microsoft YaHei"));

            // Assign the rules collection to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation with the fallback rules applied
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Ensure the presentation is properly disposed
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}