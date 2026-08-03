// -----------------------------------------------------------------------------
// Example: Extract master slide text and compare layout using C#
//
// Description:
// Demonstrates how to extract master slide text and compare it with layout text 
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, retrieves 
// raw text for each slide, checks for inconsistencies between the master slide 
// text and the layout text, and saves the presentation. This pattern helps 
// automate validation of slide content and ensures consistency across master 
// and layout definitions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Master, Slide, Text, 
// Layout, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of master slide text and compare it with layout text.
// - Build C# tools for validating PowerPoint presentation consistency.
// - Generate or transform PPTX files while ensuring master-layout alignment.
// - Integrate presentation validation into .NET applications before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFileName = "input.pptx";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Extract raw text from the presentation
            IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(inputPath, TextExtractionArrangingMode.Unarranged);

            // Compare master slide text with layout text for each slide
            for (int i = 0; i < presentationText.SlidesText.Length; i++)
            {
                ISlideText slideText = presentationText.SlidesText[i];
                string masterText = slideText.MasterText;
                string layoutText = slideText.LayoutText;

                if (!string.Equals(masterText, layoutText, StringComparison.Ordinal))
                {
                    Console.WriteLine($"Inconsistency found on slide index {i}: Master text differs from layout text.");
                }
            }

            // Save the presentation before exit
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
