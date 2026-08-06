// -----------------------------------------------------------------------------
// Example: Apply random fill to smartart nodes PNG using C#
//
// Description:
// Demonstrates how to create a SmartArt diagram, apply random solid fill colors
// to each SmartArt node shape, export the slide as a PNG image, and save the
// presentation as a PPTX file using Aspose.Slides for .NET. The example shows
// the required presentation-processing steps for PowerPoint files and produces
// the requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, PNG, Aspose.Slides for .NET, SmartArt, Random Fill,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying random fill colors to SmartArt nodes and exporting as PNG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized SmartArt in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRandomFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Initialize random number generator for colors
                Random rnd = new Random();

                // Iterate through all nodes in the SmartArt diagram
                ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                for (int i = 0; i < allNodes.Count; i++)
                {
                    ISmartArtNode node = allNodes[i];

                    // Each node can contain multiple shapes; apply color to each shape
                    ISmartArtShapeCollection shapes = node.Shapes;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        ISmartArtShape shape = shapes[j];
                        // Set solid fill type
                        shape.FillFormat.FillType = FillType.Solid;
                        // Assign a random color
                        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    }
                }

                // Export the slide containing the SmartArt as a PNG image
                using (IImage image = slide.GetImage())
                {
                    image.Save("SmartArt.png", ImageFormat.Png);
                }

                // Save the presentation to a PPTX file
                try
                {
                    pres.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
