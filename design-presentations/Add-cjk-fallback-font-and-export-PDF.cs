using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Initialize a new FontFallBackRulesCollection
            var rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add fallback rules for specific Unicode ranges
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            rules.Add(new Aspose.Slides.FontFallBackRule(0x500, 0x5FF, "Arial"));

            // Add a rule with multiple fallback fonts for emoji range
            var emojiFonts = new string[] { "Segoe UI Emoji", "Noto Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Assign the rules collection to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("FontFallbackDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}