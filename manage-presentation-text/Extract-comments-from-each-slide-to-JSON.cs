// -----------------------------------------------------------------------------
// Example: Extract comments from each slide to JSON using C#
//
// Description:
// Demonstrates how to extract comments from each slide to JSON using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Comments, Each, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extract comments from each slide to JSON.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation for saving later
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Extract comments text using PresentationFactory
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        TextExtractionArrangingMode.Unarranged);

                    ISlideText[] slidesText = presentationText.SlidesText;
                    System.Collections.Generic.List<string> commentsList = new System.Collections.Generic.List<string>();

                    for (int i = 0; i < slidesText.Length; i++)
                    {
                        string comment = slidesText[i].CommentsText;
                        commentsList.Add(comment);
                    }

                    string json = JsonSerializer.Serialize(commentsList, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(json);

                    // Save presentation before exit
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported.");
            }
        }
    }
}
