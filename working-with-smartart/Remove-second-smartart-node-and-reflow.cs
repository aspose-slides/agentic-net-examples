// -----------------------------------------------------------------------------
// Example: Remove second SmartArt node and reflow using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, locate the first SmartArt
// shape on the first slide, remove its second root node (if present), and save
// the modified presentation. The example uses Aspose.Slides for .NET and
// illustrates a typical presentation-processing workflow for SmartArt manipulation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Remove node, Reflow,
// Presentation processing, Office automation
//
// Use Cases:
// - Automate removal of a specific SmartArt node in bulk presentations.
// - Build .NET tools that modify SmartArt structures programmatically.
// - Ensure consistent layout after node removal by leveraging Aspose.Slides automatic reflow.
// - Validate and transform PPTX files as part of a CI/CD pipeline.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Find the first SmartArt shape on the slide
                Aspose.Slides.IShape smartArtShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        smartArtShape = shape;
                        break;
                    }
                }

                if (smartArtShape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                {
                    // Remove the second root node if it exists
                    if (smartArt.Nodes.Count > 1)
                    {
                        smartArt.Nodes.RemoveNode(1);
                    }
                }
                else
                {
                    Console.WriteLine("No SmartArt found on the first slide.");
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
