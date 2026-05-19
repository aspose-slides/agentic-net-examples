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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram of type ClosedChevronProcess
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add a new node to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Node with Gradient";

            // Apply a gradient fill with three stops to each shape in the node
            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
            {
                // Set fill type to gradient
                shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

                // Configure gradient properties
                shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1; // Top‑left corner

                // Add three gradient stops
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Red);
                shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, Aspose.Slides.PresetColor.Green);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Blue);

                // Verify gradient direction
                Console.WriteLine("Gradient direction for shape: " + shape.FillFormat.GradientFormat.GradientDirection);
            }

            // Save the presentation
            string outPath = "SmartArtGradient.pptx";
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}