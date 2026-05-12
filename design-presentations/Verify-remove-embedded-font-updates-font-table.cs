using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontRemovalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the test presentation
            string presentationPath = "sample.pptx";

            // Verify the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Get all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    if (allFonts == null || allFonts.Length == 0)
                    {
                        Console.WriteLine("No fonts found in the presentation.");
                        return;
                    }

                    // Choose the first font for the test
                    IFontData testFont = allFonts[0];

                    // Ensure the font is embedded before removal
                    IFontData[] embeddedFontsBefore = presentation.FontsManager.GetEmbeddedFonts();
                    bool wasAlreadyEmbedded = embeddedFontsBefore.Any(f => f.FontName == testFont.FontName);

                    if (!wasAlreadyEmbedded)
                    {
                        // Embed the font
                        presentation.FontsManager.AddEmbeddedFont(testFont, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }

                    // Verify the font is now embedded
                    IFontData[] embeddedFontsAfterAdd = presentation.FontsManager.GetEmbeddedFonts();
                    bool isEmbedded = embeddedFontsAfterAdd.Any(f => f.FontName == testFont.FontName);
                    if (!isEmbedded)
                    {
                        Console.WriteLine("Failed to embed the test font.");
                        return;
                    }

                    // Remove the embedded font
                    presentation.FontsManager.RemoveEmbeddedFont(testFont);

                    // Verify the font is no longer in the embedded fonts list
                    IFontData[] embeddedFontsAfterRemove = presentation.FontsManager.GetEmbeddedFonts();
                    bool stillEmbedded = embeddedFontsAfterRemove.Any(f => f.FontName == testFont.FontName);

                    if (stillEmbedded)
                    {
                        Console.WriteLine("Test Failed: Font still present after removal.");
                    }
                    else
                    {
                        Console.WriteLine("Test Passed: Font successfully removed from embedded fonts.");
                    }

                    // Save the presentation (required by lifecycle rules)
                    string outputPath = "FontRemovalTest_Output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}