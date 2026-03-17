using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the existing FontFallBack rules collection
            IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

            // Add a fallback rule (example: Unicode range 0x400-0x4FF uses "Times New Roman")
            rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Assign the modified collection back to the FontsManager (optional if collection is mutable)
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("FontFallbackDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}