// -----------------------------------------------------------------------------
// Example: Create XAML with embedded fonts using C#
//
// Description:
// Demonstrates how to embed all fonts used in a PowerPoint presentation
// and export the presentation to XAML format with the fonts embedded.
// The example loads a PPTX file, checks for missing embedded fonts, adds them,
// and saves the result as a XAML file using Aspose.Slides for .NET.
// This pattern can be used to ensure font fidelity when converting PPTX to XAML.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, XAML, Embedded Fonts,
// Presentation Conversion, Font Embedding, Office Automation
//
// Use Cases:
// - Convert PPTX presentations to XAML while preserving font appearance.
// - Automate embedding of missing fonts before XAML export.
// - Build .NET tools for presentation format conversion with font fidelity.
// - Validate and process PowerPoint files in CI pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.xaml";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    // Get fonts that are already embedded
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Embed any fonts that are not already embedded
                    foreach (IFontData font in allFonts)
                    {
                        bool isEmbedded = embeddedFonts.Any(ef => ef.FontName.Equals(font.FontName, StringComparison.OrdinalIgnoreCase));
                        if (!isEmbedded)
                        {
                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                    }

                    // Save the presentation as XAML with embedded fonts
                    XamlOptions xamlOptions = new XamlOptions
                    {
                        ExportHiddenSlides = true
                    };
                    presentation.Save(outputPath, SaveFormat.Xaml, xamlOptions);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
