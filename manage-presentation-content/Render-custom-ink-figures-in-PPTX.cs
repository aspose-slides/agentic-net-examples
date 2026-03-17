using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a free‑form scribble shape to simulate custom ink drawing
            Aspose.Slides.IAutoShape inkShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f,   // X position
                100f,   // Y position
                400f,   // Width
                300f    // Height
            );

            // Make the shape transparent (no fill)
            inkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Set the line to a scribble sketch type (ink‑like appearance)
            inkShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

            // Save the presentation as PPTX
            presentation.Save("CustomInkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}