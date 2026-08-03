// -----------------------------------------------------------------------------
// Example: Load PPTX and replace phrase throughout presentation using C#
//
// Description:
// Demonstrates how to load a PPTX file, replace a specific phrase throughout
// the presentation, and save the modified file using C# and Aspose.Slides for
// .NET. The example includes file existence checking, exception handling for
// unsupported formats, and uses the ReplaceText method with customizable search
// options.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Replace, Phrase,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading a PPTX and replacing a phrase across all slides.
// - Build C# utilities for PowerPoint text manipulation.
// - Integrate presentation text updates into .NET applications.
// - Validate and preprocess PPTX files before distribution or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Text to find and replace
            string oldText = "Old Phrase";
            string newText = "New Phrase";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Replace all occurrences of the specified text
                    presentation.ReplaceText(oldText, newText, new Aspose.Slides.TextSearchOptions() { WholeWordsOnly = false }, null);

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported PPTX format
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            // Handle unsupported PPT format
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
