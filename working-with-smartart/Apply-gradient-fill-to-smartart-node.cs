using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

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

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10,               // X position
                10,               // Y position
                800,              // Width
                200,              // Height
                SmartArtLayoutType.ClosedChevronProcess);

            // Add a new node to the SmartArt
            ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Gradient Node";

            // Apply gradient fill to each shape within the node
            foreach (ISmartArtShape shape in node.Shapes)
            {
                // Set fill type to gradient
                shape.FillFormat.FillType = FillType.Gradient;

                // Configure gradient properties
                shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
                shape.FillFormat.GradientFormat.LinearGradientAngle = 45f; // Angle in degrees

                // Add gradient stops (position, color)
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, System.Drawing.Color.Red);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, System.Drawing.Color.Blue);
            }

            // Save the presentation
            presentation.Save("SmartArtGradient.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}