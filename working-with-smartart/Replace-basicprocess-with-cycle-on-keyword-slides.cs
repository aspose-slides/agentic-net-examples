// -----------------------------------------------------------------------------
// Example: Replace BasicProcess with BasicCycle on keyword slides using C#
//
// Description:
// Demonstrates how to locate slides containing specific keywords and replace
// SmartArt layouts of type BasicProcess with BasicCycle using Aspose.Slides for
// .NET. The example loads a PPTX file, searches each slide for defined keywords,
// updates matching SmartArt objects, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, BasicProcess, BasicCycle,
// Keyword Search, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of BasicProcess SmartArt with BasicCycle on targeted slides.
// - Build C# utilities for keyword‑driven PowerPoint content transformation.
// - Integrate SmartArt layout updates into .NET applications or CI pipelines.
// - Validate and modify PPTX files before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Keywords to search for in slide text
        string[] keywords = new string[] { "Keyword1", "Keyword2" };

        // Iterate through slides
        foreach (ISlide slide in presentation.Slides)
        {
            bool slideContainsKeyword = false;

            // Check if slide contains any of the keywords
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                {
                    string text = autoShape.TextFrame.Text;
                    if (!string.IsNullOrEmpty(text))
                    {
                        foreach (string kw in keywords)
                        {
                            if (text.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                slideContainsKeyword = true;
                                break;
                            }
                        }
                    }
                }
                if (slideContainsKeyword)
                    break;
            }

            if (!slideContainsKeyword)
                continue;

            // Replace SmartArt layout from BasicProcess to BasicCycle
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ISmartArt smartArt)
                {
                    if (smartArt.Layout == SmartArtLayoutType.BasicProcess)
                    {
                        smartArt.Layout = SmartArtLayoutType.BasicCycle;
                    }
                }
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}
