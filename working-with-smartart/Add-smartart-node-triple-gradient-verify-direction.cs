using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

                // Add a new node to the SmartArt
                ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Node with gradient bullet";

                // Access the bullet fill format
                IFillFormat bulletFill = node.BulletFillFormat;
                if (bulletFill != null)
                {
                    // Set gradient fill type
                    bulletFill.FillType = FillType.Gradient;

                    // Configure gradient properties
                    bulletFill.GradientFormat.GradientShape = GradientShape.Linear;
                    bulletFill.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

                    // Add three gradient stops
                    bulletFill.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);
                    bulletFill.GradientFormat.GradientStops.Add(0.5f, PresetColor.Red);
                    bulletFill.GradientFormat.GradientStops.Add(1.0f, PresetColor.Orange);

                    // Verify gradient direction
                    bool isDirectionCorrect = bulletFill.GradientFormat.GradientDirection == GradientDirection.FromCorner2;
                    Console.WriteLine("Gradient direction verified: " + isDirectionCorrect);
                }

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}