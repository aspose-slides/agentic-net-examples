// -----------------------------------------------------------------------------
// Example: Add polygon bevel top 5pt bottom 3pt using C#
//
// Description:
// Demonstrates how to add a pentagon shape with a top bevel of 5 points and a
// bottom bevel of 3 points using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts the shape, configures the 3‑D bevel
// settings, and saves the result as a PPTX file. Developers can use this pattern
// to automate bevel styling of polygon shapes in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Polygon, Bevel, Top, Bottom,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Apply custom top and bottom bevels to polygon shapes programmatically.
// - Build C# utilities for PowerPoint 3‑D formatting.
// - Generate or modify PPTX files with specific shape styling in .NET apps.
// - Validate bevel configurations before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PolygonBevelExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            try
            {
                // Add a pentagon shape as a polygon placeholder
                IAutoShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.Pentagon, 100f, 100f, 200f, 200f);

                // Configure top bevel (5 points)
                shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.SoftRound;
                shape.ThreeDFormat.BevelTop.Height = 5.0;
                shape.ThreeDFormat.BevelTop.Width = 5.0;

                // Configure bottom bevel (3 points)
                shape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.SoftRound;
                shape.ThreeDFormat.BevelBottom.Height = 3.0;
                shape.ThreeDFormat.BevelBottom.Width = 3.0;
            }
            catch (Exception)
            {
                // Format not supported or other error handling
            }

            // Save the presentation
            pres.Save("PolygonBevel.pptx", SaveFormat.Pptx);
        }
    }
}
