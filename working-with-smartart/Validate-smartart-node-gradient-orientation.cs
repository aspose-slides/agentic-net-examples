using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace GradientSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a SmartArt diagram to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

            // Add a new node to the SmartArt
            ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Gradient Node";

            // Apply a three‑color gradient fill to each shape of the node
            foreach (ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = FillType.Gradient;
                shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2; // Verify this orientation later

                // Add three gradient stops
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Red);
                shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, PresetColor.Yellow);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.Green);
            }

            // Verify the gradient orientation of the first shape
            if (node.Shapes.Count > 0)
            {
                ISmartArtShape firstShape = node.Shapes[0];
                GradientDirection direction = firstShape.FillFormat.GradientFormat.GradientDirection;
                Console.WriteLine("Gradient direction set to: " + direction);
            }

            // Save the presentation
            presentation.Save("SmartArtGradient.pptx", SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}