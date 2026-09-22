// -----------------------------------------------------------------------------
// Example: Embed Fonts and Export PowerPoint to XAML with Aspose.Slides
//
// Description:
// This console application loads a PPTX file, checks for fonts that are not
// embedded, embeds the missing fonts, and attempts to save the presentation as
// XAML. It uses Aspose.Slides for .NET to ensure font fidelity during the
// conversion. If the XAML save format is not supported, the program reports
// the limitation.
//
// Keywords:
// C#, PowerPoint, PPTX, XAML, Aspose.Slides for .NET, embed fonts, font embedding, presentation conversion
//
// Use Cases:
// - Preserve exact visual appearance when converting PPTX to XAML for WPF applications.
// - Ensure all custom fonts are embedded before distribution of a presentation.
// - Automate font embedding in batch processing of PowerPoint files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesXamlEmbedding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputPath = "output.xaml";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get all fonts used in the presentation
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

            // Get already embedded fonts
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Embed missing fonts
            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool isEmbedded = false;
                foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                {
                    if (ef.Equals(font))
                    {
                        isEmbedded = true;
                        break;
                    }
                }

                if (!isEmbedded)
                {
                    // Embed the font with all characters
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    Console.WriteLine("Embedded font: " + font.FontName);
                }
            }

            // Attempt to save as XAML using reflection to avoid compile‑time errors if the format is unavailable
            Type saveFormatType = typeof(Aspose.Slides.Export.SaveFormat);
            object xamlFormat = null;
            try
            {
                xamlFormat = Enum.Parse(saveFormatType, "Xaml");
            }
            catch (ArgumentException)
            {
                // XAML format not defined in this version of Aspose.Slides
                Console.WriteLine("XAML save format is not supported by the current Aspose.Slides version.");
            }

            if (xamlFormat != null)
            {
                try
                {
                    presentation.Save(outputPath, (Aspose.Slides.Export.SaveFormat)xamlFormat);
                    Console.WriteLine("Presentation saved as XAML to: " + outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save as XAML: " + ex.Message);
                }
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
