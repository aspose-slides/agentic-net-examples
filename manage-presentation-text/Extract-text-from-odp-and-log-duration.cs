// -----------------------------------------------------------------------------
// Example: Extract text from ODP and log duration using C#
//
// Description:
// Demonstrates how to extract slide text from ODP files and log the processing
// duration using C# and Aspose.Slides for .NET. The example iterates over ODP
// files in an Input folder, measures extraction time, outputs each slide's text,
// and saves the presentation back to ODP format.
//
// Keywords:
// C#, ODP, Aspose.Slides for .NET, Extract Text, Duration Logging, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Automate extraction of text from ODP presentations.
// - Measure performance of text extraction operations.
// - Build tools for analyzing or indexing ODP slide content.
// - Integrate ODP processing into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.odp");
        foreach (string filePath in files)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                continue;
            }

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, TextExtractionArrangingMode.Unarranged);

                stopwatch.Stop();
                Console.WriteLine($"Processed {Path.GetFileName(filePath)} in {stopwatch.ElapsedMilliseconds} ms.");

                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    ISlideText slideText = presentationText.SlidesText[i];
                    Console.WriteLine($"Slide {i + 1}: {slideText.Text}");
                }

                // Save presentation before exit as required
                using (Presentation pres = new Presentation(filePath))
                {
                    pres.Save(filePath, SaveFormat.Odp);
                }
            }
            catch (Exception ex)
            {
                // If file format not supported, handle accordingly
                Console.WriteLine($"Error processing {filePath}: {ex.Message}");
            }
        }
    }
}
