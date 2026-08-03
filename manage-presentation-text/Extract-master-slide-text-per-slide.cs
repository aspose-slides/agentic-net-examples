// -----------------------------------------------------------------------------
// Example: Extract master slide text per slide using C#
//
// Description:
// Demonstrates how to extract master slide text per slide using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Master, Slide, Text, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extract master slide text per slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Extract text including master slide text
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                inputPath,
                Aspose.Slides.TextExtractionArrangingMode.Arranged);

            Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;

            for (int i = 0; i < slidesText.Length; i++)
            {
                Aspose.Slides.ISlideText slideText = slidesText[i];
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Slide " + (i + 1) + " Text:");
                sb.AppendLine(slideText.Text ?? string.Empty);
                sb.AppendLine("--- Master Text ---");
                sb.AppendLine(slideText.MasterText ?? string.Empty);

                string outputFile = $"Slide_{i + 1}.txt";
                File.WriteAllText(outputFile, sb.ToString());
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
