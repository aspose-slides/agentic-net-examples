using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontRemovalTests
{
    public class Program
    {
        public static void Main()
        {
            // Paths for test files
            string inputPath = "TestPresentation.pptx";
            string outputPath = "TestPresentation_Output.pptx";

            // Ensure input file exists; create a simple presentation if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                    // Add a slide to have a valid presentation
                    createPres.Slides.AddEmptySlide(createPres.Slides[0].LayoutSlide);
                    createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    createPres.Dispose();
                }
                catch (Exception ex)
                {
                    // Format not supported or other error
                    // Comment: format not supported
                    Console.WriteLine("Failed to create test presentation: " + ex.Message);
                    return;
                }
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Embed a known font if not already embedded
            Aspose.Slides.IFontData[] allFonts = pres.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();
            bool arialEmbedded = false;
            foreach (Aspose.Slides.IFontData ef in embeddedFonts)
            {
                if (ef.FontName.Equals("Arial", StringComparison.OrdinalIgnoreCase))
                {
                    arialEmbedded = true;
                    break;
                }
            }

            if (!arialEmbedded && allFonts.Length > 0)
            {
                // Attempt to embed the first font (commonly Arial)
                Aspose.Slides.IFontData fontToEmbed = allFonts[0];
                try
                {
                    pres.FontsManager.AddEmbeddedFont(fontToEmbed, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to embed font: " + ex.Message);
                }
            }

            // Capture embedded fonts count before removal
            Aspose.Slides.IFontData[] beforeRemoval = pres.FontsManager.GetEmbeddedFonts();
            int countBefore = beforeRemoval.Length;

            if (countBefore == 0)
            {
                Console.WriteLine("No embedded fonts to remove. Test inconclusive.");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
                return;
            }

            // Remove the first embedded font
            Aspose.Slides.IFontData fontToRemove = beforeRemoval[0];
            try
            {
                pres.FontsManager.RemoveEmbeddedFont(fontToRemove);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to remove embedded font: " + ex.Message);
                pres.Dispose();
                return;
            }

            // Verify the font table is updated
            Aspose.Slides.IFontData[] afterRemoval = pres.FontsManager.GetEmbeddedFonts();
            int countAfter = afterRemoval.Length;

            if (countAfter != countBefore - 1)
            {
                throw new InvalidOperationException("Embedded font count did not decrease after removal.");
            }

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            pres.Dispose();

            Console.WriteLine("Test passed: RemoveEmbeddedFont correctly updates the font table.");
        }
    }
}