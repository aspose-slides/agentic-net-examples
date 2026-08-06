// -----------------------------------------------------------------------------
// Example: Update assistant flag from hierarchy and save using C#
//
// Description:
// Demonstrates how to iterate through SmartArt nodes in a presentation,
// set the IsAssistant flag based on a simple hierarchy rule (even position),
// and save the modified presentation using Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, IsAssistant, Node,
// Hierarchy, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate updating SmartArt assistant flags based on hierarchy.
// - Build C# tools for PowerPoint SmartArt manipulation.
// - Generate or transform PPTX files in .NET applications.
// - Validate SmartArt node properties before publishing or integration.
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
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    ISmartArt smart = (ISmartArt)shape;
                    foreach (ISmartArtNode node in smart.AllNodes)
                    {
                        // Example external hierarchy logic: set assistant flag based on node position
                        if (node.Position % 2 == 0)
                        {
                            node.IsAssistant = true;
                        }
                        else
                        {
                            node.IsAssistant = false;
                        }
                    }
                }
            }
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported comment
        }
        finally
        {
            if (pres != null)
                pres.Dispose();
        }
    }
}
