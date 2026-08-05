// -----------------------------------------------------------------------------
// Example: Add diagonal stripe pattern fill to textbox using C#
//
// Description:
// Demonstrates how to add a diagonal stripe pattern fill to a textbox shape 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts a rectangle auto shape as a textbox, applies a downward diagonal 
// stripe pattern fill with custom foreground and background colors, and saves 
// the result as a PPTX file. This showcases essential presentation‑processing 
// steps for PowerPoint automation in a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Diagonal Stripe, Pattern Fill, 
// Textbox, Presentation Automation, Office Automation
//
// Use Cases:
// - Automate adding diagonal stripe pattern fill to textboxes in PPTX files.
// - Build C# utilities for PowerPoint shape styling and formatting.
// - Generate or modify presentations with custom pattern fills in .NET apps.
// - Validate visual styling workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddDiagonalStripePatternFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape that will act as a text box
            IAutoShape textBox = slide.Shapes.AddAutoShape(
                ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                300,   // Width
                100);  // Height

            // Add a text frame to the shape
            textBox.AddTextFrame("Sample Text");

            // Apply pattern fill
            textBox.FillFormat.FillType = FillType.Pattern;

            // Set the pattern style to a diagonal stripe (using an existing enum value)
            textBox.FillFormat.PatternFormat.PatternStyle = PatternStyle.DownwardDiagonal;

            // Set foreground (stripe) color to gray
            textBox.FillFormat.PatternFormat.ForeColor.Color = Color.Gray;

            // Set background color (optional, here set to white)
            textBox.FillFormat.PatternFormat.BackColor.Color = Color.White;

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}
