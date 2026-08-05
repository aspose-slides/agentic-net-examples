// -----------------------------------------------------------------------------
// Example: Add ellipse rotation 45 degrees to PNG using C#
//
// Description:
// Demonstrates how to add an ellipse shape rotated by 45 degrees to a slide,
// export that slide as a PNG image, and save the presentation as a PPTX file
// using Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces the requested output in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Ellipse, Rotation,
// Degrees, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an ellipse with a 45-degree rotation and exporting to PNG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEllipseRotation
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

                // Add an ellipse shape to the slide
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 100f, 200f, 150f);

                // Set rotation angle to 45 degrees
                ellipse.Rotation = 45f;

                // Export the slide as PNG
                try
                {
                    using (IImage slideImage = slide.GetImage())
                    {
                        slideImage.Save("SlideWithEllipse.png", ImageFormat.Png);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }

                // Save the presentation before exiting
                try
                {
                    presentation.Save("PresentationWithEllipse.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
