using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var outputPath = "FontFallbackPresentation.pptx";

                // Create a new presentation
                var presentation = new Presentation();

                // Initialize a new FontFallBackRulesCollection
                var rules = new FontFallBackRulesCollection();

                // Add fallback rule: Unicode range 0x0400-0x04FF uses "Arial"
                rules.Add(new FontFallBackRule(0x0400, 0x04FF, "Arial"));

                // Add fallback rule: Unicode range 0x0500-0x05FF uses "Times New Roman"
                rules.Add(new FontFallBackRule(0x0500, 0x05FF, "Times New Roman"));

                // Assign the rules collection to the presentation's FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = rules;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}