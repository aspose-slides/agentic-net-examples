using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

        // Add a node to the SmartArt
        ISmartArtNode node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "Node with Gradient";

        // Apply a three‑stop gradient fill to each shape in the node
        foreach (ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

            // First stop at 0%
            shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);
            // Second stop at 50%
            shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, PresetColor.Red);
            // Third stop at 100%
            shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Blue);
        }

        // Verify the gradient orientation
        foreach (ISmartArtShape shape in node.Shapes)
        {
            GradientDirection direction = shape.FillFormat.GradientFormat.GradientDirection;
            Console.WriteLine("Gradient direction: " + direction);
        }

        // Save the presentation
        try
        {
            presentation.Save("SmartArtGradient.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            presentation.Dispose();
        }
    }
}