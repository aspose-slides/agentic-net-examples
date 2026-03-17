using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentationPath = "input.pptx";
                using (var presentation = new Presentation(presentationPath))
                {
                    // Define source (missing) font and replacement font
                    var sourceFont = new FontData("MissingFont");
                    var replacementFont = new FontData("Arial");

                    // Replace the missing font with the replacement font
                    presentation.FontsManager.ReplaceFont(sourceFont, replacementFont);

                    // Optionally, display the substitution info
                    foreach (var substitution in presentation.FontsManager.GetSubstitutions())
                    {
                        Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                    }

                    // Save the updated presentation
                    var outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}