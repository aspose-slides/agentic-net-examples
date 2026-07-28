// -----------------------------------------------------------------------------
// Example: Export slide titles to CSV file using C#
//
// Description:
// Demonstrates how to export slide titles from a PowerPoint presentation to a CSV
// file using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// iterates through its slides, extracts each slide's title (placeholder in this
// sample), and writes the slide index and title to a CSV file. This pattern can
// be used to automate PPTX workflows, generate reports, or integrate presentation
// data extraction into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, Titles, CSV, File,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of slide titles to CSV for reporting or analysis.
// - Build C# tools for PowerPoint presentation data extraction.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation content before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputCsv = "slide_titles.csv";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputCsv))
                {
                    writer.WriteLine("SlideIndex,Title");
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        // Placeholder title; replace with actual extraction if needed
                        string title = $"Slide {i + 1}";
                        writer.WriteLine($"{i + 1},\"{title.Replace("\"", "\"\"")}\"");
                    }
                }

                // Save presentation before exit (no modifications made)
                pres.Save(inputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
