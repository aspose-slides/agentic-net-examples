// -----------------------------------------------------------------------------
// Example: Add star three stop gradient fill using C#
//
// Description:
// Demonstrates how to add a five‑pointed star shape with a three‑stop gradient
// fill (blue → green → yellow) using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts the star, configures the gradient fill,
// and saves the result as a PPTX file. This pattern can be used to automate
// gradient styling of shapes in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Star, Three‑Stop Gradient, Fill,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a star shape with a custom three‑stop gradient fill.
// - Build C# utilities for styling shapes in PowerPoint files.
// - Generate or modify PPTX presentations programmatically.
// - Validate gradient fill configurations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a five‑pointed star shape
            IAutoShape star = slide.Shapes.AddAutoShape(ShapeType.FivePointedStar, 100, 100, 200, 200);

            // Apply a three‑stop gradient fill (blue → green → yellow)
            star.FillFormat.FillType = FillType.Gradient;
            star.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            star.FillFormat.GradientFormat.GradientStops.Clear();
            star.FillFormat.GradientFormat.GradientStops.Add(0f, Color.Blue);
            star.FillFormat.GradientFormat.GradientStops.Add(0.5f, Color.Green);
            star.FillFormat.GradientFormat.GradientStops.Add(1f, Color.Yellow);

            // Save the presentation
            pres.Save("StarGradient.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other error
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
