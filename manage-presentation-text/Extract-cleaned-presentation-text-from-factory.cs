// -----------------------------------------------------------------------------
// Example: Extract cleaned presentation text from factory using C#
//
// Description:
// Demonstrates how to extract cleaned presentation text from a PowerPoint file
// using Aspose.Slides PresentationFactory with arranged text extraction mode,
// remove empty or whitespace‑only lines, write the result to a text file, and
// save a copy of the original presentation. This console application shows the
// essential steps for processing PPTX files in .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Cleaned, Presentation,
// Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of cleaned presentation text from PPTX files.
// - Build C# utilities for PowerPoint content analysis or migration.
// - Generate plain‑text representations of slides for indexing or search.
// - Validate and transform presentation content before further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractCleanedText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path
            string inputPath = "input.pptx";
            // Output text file path
            string outputPath = "cleaned_text.txt";
            // Path for saving a copy of the presentation
            string savedPresentationPath = "saved_output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                // Extract raw text using PresentationFactory with a valid extraction mode
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Arranged);

                // Build cleaned text by removing empty or whitespace-only lines
                StringBuilder cleanedBuilder = new StringBuilder();
                foreach (Aspose.Slides.ISlideText slideText in presentationText.SlidesText)
                {
                    string text = slideText.Text;
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        cleanedBuilder.AppendLine(text);
                    }
                }

                // Write the cleaned content to a text file
                File.WriteAllText(outputPath, cleanedBuilder.ToString());

                // Load the presentation and save a copy (required by the task)
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Text extraction and cleaning completed successfully.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (NotSupportedException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
