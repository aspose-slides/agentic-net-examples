// -----------------------------------------------------------------------------
// Example: Add underline styling to selected text using C#
//
// Description:
// Demonstrates how to add underline styling to selected text using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Underline, Styling, Selected, 
// Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add underline styling to selected text.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Apply underline styling to all portions of text in the shape
                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                portion.PortionFormat.FontUnderline = TextUnderlineType.Single;
                            }
                        }
                    }
                }
            }

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
