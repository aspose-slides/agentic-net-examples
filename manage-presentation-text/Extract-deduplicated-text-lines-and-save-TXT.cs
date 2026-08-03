// -----------------------------------------------------------------------------
// Example: Extract deduplicated text lines and save TXT using C#
//
// Description:
// Demonstrates how to extract deduplicated text lines from a PowerPoint
// presentation and save them to a TXT file using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, extracts raw slide text in unarranged mode,
// removes duplicate lines, writes the unique lines to a text file, and saves
// the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Deduplicated, Text,
// Lines, TXT, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of unique text lines from PPTX files.
// - Build C# utilities for PowerPoint content analysis.
// - Generate plain‑text representations of presentations.
// - Integrate text extraction into .NET automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractDeduplicatedText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output text file path
            string outputPath = "deduplicated.txt";

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
                    // Extract raw text from the presentation (unarranged mode)
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        TextExtractionArrangingMode.Unarranged);

                    // Use a HashSet to store unique lines
                    HashSet<string> uniqueLines = new HashSet<string>(StringComparer.Ordinal);

                    // Iterate through each slide's extracted text
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        string text = slideText.Text;
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            // Split the slide text into individual lines
                            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string line in lines)
                            {
                                uniqueLines.Add(line);
                            }
                        }
                    }

                    // Write the deduplicated lines to the output file
                    File.WriteAllLines(outputPath, uniqueLines);

                    // Save the presentation before exiting (using the correct SaveFormat enum)
                    presentation.Save("saved_output.pptx", SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions (e.g., when trying to save in an unsupported format)
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            // General exception handling (including any missing type exceptions)
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
