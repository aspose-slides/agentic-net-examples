// -----------------------------------------------------------------------------
// Example: Replace placeholder text using regex using C#
//
// Description:
// Demonstrates how to replace placeholder text using regex with Aspose.Slides for .NET.
// The example loads a PPTX file, searches for placeholders like [PLACEHOLDER] in all
// text frames (including master slides), replaces them with a specified value, and
// saves the updated presentation. This pattern can be used to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Placeholder, Text,
// Regex, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replace placeholder text using regex.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace ReplacePlaceholderText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define the regular expression to find placeholder text (e.g., [PLACEHOLDER])
                    Regex placeholderRegex = new Regex(@"\[PLACEHOLDER\]");

                    // Retrieve all text frames, including those in master slides
                    ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, true);

                    // Replace each placeholder occurrence with the desired text
                    foreach (ITextFrame textFrame in textFrames)
                    {
                        textFrame.ReplaceRegex(placeholderRegex, "ActualValue", null);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
