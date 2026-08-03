// -----------------------------------------------------------------------------
// Example: Extract slide texts to JSON array using C#
//
// Description:
// Demonstrates how to extract raw text from each slide of a PowerPoint
// presentation and serialize it into a JSON array using Aspose.Slides for .NET.
// The example loads a PPTX file, collects slide texts, writes them to a JSON
// file, and saves the original presentation to a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Slide, Text, JSON, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide texts for indexing or search.
// - Generate JSON representations of presentations for web services.
// - Build .NET tools that need to analyze or transform PPTX content.
// - Validate slide content before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file name
            System.String inputFileName = "input.pptx";
            // Output JSON file name
            System.String jsonOutputFile = "slideTexts.json";
            // Output presentation file name (saved before exit)
            System.String presentationOutputFile = "output.pptx";

            // Build full path for the input file
            System.String filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), inputFileName);

            // Verify that the input file exists
            if (!System.IO.File.Exists(filePath))
            {
                System.Console.WriteLine("Input file does not exist: " + filePath);
                return;
            }

            try
            {
                // Extract raw text from the presentation
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(filePath, Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                // Prepare an array to hold each slide's text
                System.String[] slideTexts = new System.String[presentationText.SlidesText.Length];

                // Iterate through slides and collect text
                for (System.Int32 i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                    slideTexts[i] = slideText.Text;
                }

                // Serialize the array to JSON
                System.String json = System.Text.Json.JsonSerializer.Serialize(slideTexts, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

                // Write JSON to the output file
                System.IO.File.WriteAllText(jsonOutputFile, json);

                // Load the presentation to satisfy the requirement of saving before exit
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))
                {
                    // Save the presentation (could be the same or a new file)
                    pres.Save(presentationOutputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                System.Console.WriteLine("Extraction completed. JSON saved to " + jsonOutputFile);
            }
            catch (System.Exception ex)
            {
                // If the file format is not supported, handle the exception
                // format not supported
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
