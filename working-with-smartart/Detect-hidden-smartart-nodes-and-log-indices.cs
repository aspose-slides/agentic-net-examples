// -----------------------------------------------------------------------------
// Example: Detect hidden smartart nodes and log indices using C#
//
// Description:
// Demonstrates how to detect hidden SmartArt nodes within a PowerPoint presentation
// and log their slide and node indices using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through slides and SmartArt shapes,
// identifies hidden nodes, outputs their locations, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Hidden, SmartArt,
// Nodes, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate detection of hidden SmartArt nodes and log their positions.
// - Build C# utilities for PowerPoint presentation analysis.
// - Validate SmartArt content before publishing or further processing.
// - Integrate SmartArt inspection into .NET applications handling PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                    {
                        if (node.IsHidden)
                        {
                            Console.WriteLine($"Hidden node found at slide {slideIndex}, node index {nodeIndex}");
                        }
                        nodeIndex++;
                    }
                }
            }
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        if (presentation != null)
        {
            presentation.Dispose();
        }
    }
}
