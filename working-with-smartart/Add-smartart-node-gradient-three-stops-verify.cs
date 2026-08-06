// -----------------------------------------------------------------------------
// Example: Add smartart node gradient three stops verify using C#
//
// Description:
// Demonstrates how to add a SmartArt node with a three‑stop gradient fill,
// verify the gradient direction, and save the presentation using C# and
// Aspose.Slides for .NET. The example creates a new presentation, inserts a
// ClosedChevronProcess SmartArt diagram, adds a node, applies a linear
// gradient (red‑green‑blue) to each shape in the node, outputs the gradient
// direction to the console, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Gradient,
// Three Stops, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a three‑stop gradient to SmartArt nodes.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom SmartArt styling.
// - Validate SmartArt gradient configurations before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram of type ClosedChevronProcess
            SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 800, 60, SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add a new node to the SmartArt
            SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Node with Gradient";

            // Apply a gradient fill with three stops to each shape in the node
            foreach (SmartArt.ISmartArtShape shape in node.Shapes)
            {
                // Set fill type to gradient
                shape.FillFormat.FillType = FillType.Gradient;

                // Configure gradient properties
                shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner1; // Top‑left corner

                // Add three gradient stops
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Red);
                shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, PresetColor.Green);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.Blue);

                // Verify gradient direction
                Console.WriteLine("Gradient direction for shape: " + shape.FillFormat.GradientFormat.GradientDirection);
            }

            // Save the presentation
            string outPath = "SmartArtGradient.pptx";
            presentation.Save(outPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
