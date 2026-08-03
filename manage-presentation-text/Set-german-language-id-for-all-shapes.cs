// -----------------------------------------------------------------------------
// Example: Set german language id for all shapes using C#
//
// Description:
// Demonstrates how to set the German language identifier (de-DE) for every text
// portion within all shapes on the first slide of a PowerPoint presentation
// using Aspose.Slides for .NET. The example loads an existing PPTX file,
// updates language metadata for each text portion, and saves the modified
// presentation as a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, German, Language ID, Shapes,
// Text Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure correct language metadata for spell checking and accessibility.
// - Automate localization preparation for PowerPoint files.
// - Build tools that standardize language settings across presentations.
// - Integrate language ID updates into .NET-based document workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all shapes on the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                    for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                    {
                        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[p];
                        for (int pt = 0; pt < paragraph.Portions.Count; pt++)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[pt];
                            // Set language metadata to German
                            portion.PortionFormat.LanguageId = "de-DE";
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}
