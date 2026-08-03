// -----------------------------------------------------------------------------
// Example: Extract text from each slide and save using C#
//
// Description:
// Demonstrates how to extract raw text from each slide of a PPTX file using
// Aspose.Slides for .NET in Unarranged mode, save each slide's content to a
// separate UTF‑8 encoded text file, and re‑save the original presentation.
// This pattern is useful for automating slide‑level text extraction and
// simple presentation round‑tripping in .NET applications.
//
// Keywords:
// C#, Aspose.Slides, PPTX, Extract Text, Slide, UTF-8, Presentation Processing,
// Office Automation, Save Format
//
// Use Cases:
// - Automate extraction of slide text for indexing or analysis.
// - Generate per‑slide text files for downstream processing.
// - Build .NET tools that need to read and rewrite PowerPoint presentations.
// - Validate and transform PPTX content in batch workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "sample.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Extract raw text from each slide using the Unarranged mode
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;

                // Save each slide's text to a separate UTF‑8 encoded file
                for (int i = 0; i < slidesText.Length; i++)
                {
                    string slideContent = slidesText[i].Text ?? string.Empty;
                    string outputFile = $"slide_{i + 1}.txt";
                    File.WriteAllText(outputFile, slideContent, Encoding.UTF8);
                }

                // Load the presentation and save it (required by the rule to save before exit)
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
