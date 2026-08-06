// -----------------------------------------------------------------------------
// Example: Extract smartart text from PPTX using C#
//
// Description:
// Demonstrates how to extract SmartArt text from a PPTX file using C# and 
// Aspose.Slides for .NET. The example loads a presentation, iterates through 
// all slides and shapes, identifies SmartArt objects, and prints the text 
// contained in each SmartArt node's shapes. The presentation is then saved 
// unchanged, illustrating a typical workflow for PowerPoint text extraction 
// and file handling in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, SmartArt, Text, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SmartArt text from PPTX files.
// - Build C# utilities for PowerPoint content analysis.
// - Integrate SmartArt text retrieval into .NET applications.
// - Validate and process presentation data before further automation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            var presentation = new Presentation(inputPath);

            foreach (var slide in presentation.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                    {
                        var nodes = smartArt.AllNodes;
                        foreach (var node in nodes)
                        {
                            foreach (var smartShape in node.Shapes)
                            {
                                if (smartShape.TextFrame != null)
                                {
                                    Console.WriteLine(smartShape.TextFrame.Text);
                                }
                            }
                        }
                    }
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
