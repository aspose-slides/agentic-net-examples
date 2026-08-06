// -----------------------------------------------------------------------------
// Example: Apply assistant flag to SmartArt nodes from external hierarchy and save using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, apply the IsAssistant
// flag to SmartArt nodes based on an external hierarchy dictionary, and save
// the modified presentation using Aspose.Slides for .NET. The example shows
// the required steps for processing SmartArt diagrams, updating node properties,
// and persisting the changes in a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Assistant Flag, Hierarchy, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting assistant flags on SmartArt nodes from external data.
// - Build C# utilities for PowerPoint SmartArt manipulation.
// - Generate or transform PPTX files with customized SmartArt hierarchy.
// - Validate SmartArt configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
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

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load presentation
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // Handle unsupported format
            // format not supported
            return;
        }

        try
        {
            // Get first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Example external hierarchy data: node index -> IsAssistant flag
            Dictionary<int, bool> hierarchy = new Dictionary<int, bool>();
            hierarchy.Add(0, false);
            hierarchy.Add(1, true);
            hierarchy.Add(2, false);
            // Add more entries as needed

            // Iterate through shapes to find SmartArt diagrams
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        bool isAssistant;
                        if (hierarchy.TryGetValue(nodeIndex, out isAssistant))
                        {
                            // Set IsAssistant based on external data
                            node.IsAssistant = isAssistant;
                        }
                        nodeIndex++;
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            // Ensure resources are released
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
