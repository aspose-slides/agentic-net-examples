// -----------------------------------------------------------------------------
// Example: Replace deprecated font with modern alternative using C#
//
// Description:
// Demonstrates how to replace a deprecated font with a modern alternative in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, substitutes the specified source font with a
// destination font across the entire presentation, and saves the result.
// This pattern can be used to modernize legacy presentations or enforce
// corporate branding.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Font, Deprecated Font,
// Modern Font, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the replacement of outdated fonts in bulk presentations.
// - Ensure brand compliance by updating legacy slide decks.
// - Integrate font migration into .NET based document processing pipelines.
// - Prepare presentations for publishing with up‑to‑date typography.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Define the deprecated font and the modern replacement
                    Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("OldFontName");
                    Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("NewFontName");

                    // Replace the font throughout the presentation
                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                    // Save the updated presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
