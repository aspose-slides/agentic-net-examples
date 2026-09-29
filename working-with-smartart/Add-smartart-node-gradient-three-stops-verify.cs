// -----------------------------------------------------------------------------
// Example: Add SmartArt Node with Three‑Stop Linear Gradient Fill using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, inserts a
// ClosedChevronProcess SmartArt diagram, adds a node, applies a linear gradient
// (red‑green‑blue) with three stops to each shape in the node, outputs the
// gradient direction to the console, and saves the file as a PPTX. It uses
// Aspose.Slides for .NET and demonstrates gradient fill handling for SmartArt.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, gradient fill, three stops
//
// Use Cases:
// - Generate automated slide decks with branded gradient graphics.
// - Programmatically customize SmartArt diagrams for reporting tools.
// - Create template‑based presentations with dynamic visual styles.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "SmartArtGradient.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a ClosedChevronProcess SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 800, 200,
                Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add a new node to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Gradient Node";

            // Apply a three‑stop linear gradient to each shape in the node
            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1;

                // Add gradient stops: Red at 0%, Green at 50%, Blue at 100%
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Red);
                shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, Aspose.Slides.PresetColor.Green);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Blue);

                // Verify and output the gradient direction
                Console.WriteLine(
                    "Shape \"{0}\" gradient direction: {1}",
                    shape.Name,
                    shape.FillFormat.GradientFormat.GradientDirection);
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved to \"{0}\".", outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
