// -----------------------------------------------------------------------------
// Example: Add ellipse 1pt line soft edge 5pt using C#
//
// Description:
// Demonstrates how to add an ellipse with a 1 pt line and a 5 pt soft edge
// effect using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts the ellipse on the first slide, configures the line
// width and soft‑edge radius, and saves the result as a PPTX file. This pattern
// can be used to automate shape styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line, Soft Edge,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipses with specific line thickness and soft‑edge styling.
// - Build C# utilities for PowerPoint shape manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate visual formatting of shapes before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 100f, 200f, 150f);

                // Set line width to 1 point
                ellipse.LineFormat.Width = 1f;

                // Enable soft edge effect and set radius to 5 points
                ellipse.EffectFormat.EnableSoftEdgeEffect();
                ellipse.EffectFormat.SoftEdgeEffect.Radius = 5.0;

                // Save the presentation
                presentation.Save("EllipseSoftEdge.pptx", SaveFormat.Pptx);
            }
        }
    }
}
