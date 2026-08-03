// -----------------------------------------------------------------------------
// Example: Extract text and calculate total word count using C#
//
// Description:
// Demonstrates how to extract raw text from a PowerPoint presentation and
// calculate the total word count using Aspose.Slides for .NET. The example
// loads a PPTX file, iterates through each slide's text, counts words, and
// outputs the total count. It also shows how to save the presentation
// unchanged, illustrating typical presentation-processing steps.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract Text, Word Count,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of text and word count statistics from PPTX files.
// - Build C# utilities for analyzing presentation content.
// - Integrate word count metrics into reporting or quality‑control pipelines.
// - Validate presentation text before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Extract raw text from the presentation using the provided rule
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(inputPath, Aspose.Slides.TextExtractionArrangingMode.Unarranged);
            int totalWordCount = 0;
            Aspose.Slides.ISlideText[] slides = presentationText.SlidesText;
            for (int i = 0; i < slides.Length; i++)
            {
                string slideText = slides[i].Text;
                if (!string.IsNullOrEmpty(slideText))
                {
                    string[] words = slideText.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    totalWordCount += words.Length;
                }
            }

            Console.WriteLine("Total word count: " + totalWordCount);

            // Load the presentation to save it before exiting (no modifications made)
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle the exception
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
