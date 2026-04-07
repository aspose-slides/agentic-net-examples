using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectMissingFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Configure load options to substitute missing fonts with a default font
                LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "Arial";

                // Load the presentation with the specified load options
                using (Presentation presentation = new Presentation(sourcePath, loadOptions))
                {
                    // Display font substitution information (if any)
                    foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                    {
                        Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                    }

                    // Save the presentation after enabling font substitution
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}