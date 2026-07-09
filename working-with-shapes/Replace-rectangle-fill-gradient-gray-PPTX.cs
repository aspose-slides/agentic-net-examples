using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Apply gradient fill from light gray to dark gray
        rectangle.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        rectangle.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        rectangle.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        rectangle.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.LightGray);
        rectangle.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.DarkGray);

        // Save the presentation
        try
        {
            presentation.Save("GradientRectangles.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose presentation
        presentation.Dispose();
    }
}