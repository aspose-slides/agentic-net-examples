using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            // Load presentation with a non‑existent default regular font
            var loadOptions = new LoadOptions();
            loadOptions.DefaultRegularFont = "NonExistentFont";

            using (var presentation = new Presentation(inputPath, loadOptions))
            {
                // Show current font substitutions
                Console.WriteLine("Font substitutions before clearing fallback rules:");
                foreach (var info in presentation.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine($"{info.OriginalFontName} -> {info.SubstitutedFontName}");
                }

                // Clear fallback font rules
                var emptyRules = new FontFallBackRulesCollection();
                presentation.FontsManager.FontFallBackRulesCollection = emptyRules;

                // Show font substitutions after clearing fallback rules
                Console.WriteLine("Font substitutions after clearing fallback rules:");
                foreach (var info in presentation.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine($"{info.OriginalFontName} -> {info.SubstitutedFontName}");
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}