// -----------------------------------------------------------------------------
// Example: Apply gradient three stops orientation verify using C#
//
// Description:
// Demonstrates how to apply a three‑stop linear gradient to the shapes of a
// SmartArt node, verify that the gradient orientation is set to FromCorner1,
// and save the resulting presentation using Aspose.Slides for .NET.
// The example covers creating a presentation, adding SmartArt, configuring
// gradient fill properties, checking the orientation, and persisting the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Gradient, Three, Stops,
// SmartArt, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a three‑stop gradient with a specific orientation to
//   SmartArt elements.
// - Build C# utilities for PowerPoint presentation processing that involve
//   SmartArt styling.
// - Generate or transform PPTX files with customized SmartArt graphics in .NET
//   applications.
// - Validate gradient orientation settings before publishing or further
//   integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        var node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "Node with Gradient";

        foreach (ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner1;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Red);
            shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Blue);
        }

        foreach (ISmartArtShape shape in node.Shapes)
        {
            if (shape.FillFormat.GradientFormat.GradientDirection == GradientDirection.FromCorner1)
            {
                Console.WriteLine("Gradient orientation is FromCorner1 as expected.");
            }
            else
            {
                Console.WriteLine("Gradient orientation differs.");
            }
        }

        var outPath = "GradientSmartArt.pptx";
        try
        {
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        presentation.Dispose();
    }
}
