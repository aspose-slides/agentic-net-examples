// -----------------------------------------------------------------------------
// Example: Add rounded rectangle to slide three with solid fill using C#
//
// Description:
// Demonstrates how to add a rounded rectangle shape to the third slide of a
// presentation and apply a solid light‑blue fill using Aspose.Slides for .NET.
// The example creates a new presentation (or uses an empty one), ensures at
// least three slides exist, inserts the shape on slide index 2, sets the
// corner radius, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rounded Rectangle, Slide 3,
// Solid Fill, Presentation Automation, Office Automation
//
// Use Cases:
// - Programmatically add rounded rectangle shapes to a specific slide.
// - Apply solid color fills to shapes in generated presentations.
// - Build .NET utilities that modify or enrich PPTX files.
// - Automate slide layout adjustments for reporting or templating.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Ensure there are at least three slides
        while (pres.Slides.Count < 3)
        {
            pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        }

        // Get the third slide (index 2)
        Aspose.Slides.ISlide slide = pres.Slides[2];

        // Add a rounded rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.RoundCornerRectangle, 100, 100, 200, 100);

        // Set corner radius to 10 points via adjustment
        for (int i = 0; i < shape.Adjustments.Count; i++)
        {
            if (shape.Adjustments[i].Type == Aspose.Slides.ShapeAdjustmentType.Radius)
            {
                shape.Adjustments[i].RawValue = 10;
            }
        }

        // Apply solid fill (light blue color)
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Save the presentation
        pres.Save("RoundedRectangleSlide3.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
