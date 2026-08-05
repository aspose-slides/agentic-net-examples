// -----------------------------------------------------------------------------
// Example: Set ellipse line width 2pt dashdot using C#
//
// Description:
// Demonstrates how to set the line width of ellipse shapes to 2 points and
// apply a dash‑dot line style using C# and Aspose.Slides for .NET. The example
// loads an existing presentation (or creates a new one), finds all ellipse
// auto‑shapes, modifies their line formatting, and saves the result.
// This pattern can be used to automate line‑style adjustments in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line Width, DashDot,
// Shape Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Apply a 2pt dash‑dot border to all ellipses in a presentation.
// - Build C# utilities for bulk updating shape line styles in PPTX files.
// - Integrate line‑formatting logic into .NET applications that generate or
//   modify PowerPoint content.
// - Ensure consistent visual styling of ellipse shapes across slides.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;

        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
                // Add a sample ellipse so the code has something to modify
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
            }

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = shapes[shapeIndex];

                    // Process only auto shapes that are ellipses
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                    {
                        // Change line width to 2 points
                        autoShape.LineFormat.Width = 2;

                        // Set dash style to DashDot
                        autoShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
