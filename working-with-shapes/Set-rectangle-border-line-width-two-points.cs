using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape (float literals for coordinates and size)
            Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                200f,  // Width
                100f   // Height
            );

            // Set the line width to 2 points (property expects double)
            rectangle.LineFormat.Width = 2.0;

            // Retrieve the effective line width (read‑only double)
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = rectangle.LineFormat.GetEffective();
            double effectiveWidth = effectiveLine.Width;

            Console.WriteLine("Effective line width: " + effectiveWidth);

            // Save the presentation (must save before exiting)
            presentation.Save("RectangleLineWidth.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}