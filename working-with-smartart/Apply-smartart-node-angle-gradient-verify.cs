using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

        // Get the first node of the SmartArt
        ISmartArtNode firstNode = smartArt.Nodes[0];

        // Get the first shape associated with the node
        ISmartArtShape shape = firstNode.Shapes[0];

        // Apply a gradient fill to the shape
        shape.FillFormat.FillType = FillType.Gradient;
        shape.FillFormat.GradientFormat.LinearGradientAngle = 45f; // Angle in degrees

        // Clear any existing gradient stops
        shape.FillFormat.GradientFormat.GradientStops.Clear();

        // Add gradient stops (position, color)
        shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, Color.Red);
        shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, Color.Blue);

        // Save the presentation
        pres.Save("SmartArtGradient.pptx", SaveFormat.Pptx);
    }
}