// -----------------------------------------------------------------------------
// Example: Set assistant flag on SmartArt node and verify indentation using C#
//
// Description:
// Demonstrates how to set the IsAssistant flag on a SmartArt node and verify
// its hierarchical indentation (Level) using Aspose.Slides for .NET. The
// example loads a PPTX file, accesses the first SmartArt shape, modifies the
// first node, outputs the node level, and saves the updated presentation.
// This pattern can be used for automating SmartArt manipulation and validation
// in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Assistant Flag, Node,
// Level, Hierarchical Indentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting the assistant flag on SmartArt nodes.
// - Validate SmartArt hierarchy after modifications.
// - Build .NET tools for PowerPoint SmartArt manipulation.
// - Integrate SmartArt processing into presentation workflows.
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
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load the presentation
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        try
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Iterate through shapes to find SmartArt
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

                    // Ensure there is at least one node
                    if (smart.AllNodes.Count > 0)
                    {
                        // Get the first node
                        Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

                        // Set the node as an assistant
                        node.IsAssistant = true;

                        // Verify hierarchical indentation via Level property
                        int level = node.Level;
                        Console.WriteLine("Node Level after setting IsAssistant: " + level);
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation
            if (pres != null)
                pres.Dispose();
        }
    }
}
