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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50, 50, 300, 200);

            // Apply gradient fill
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

            // Define start (purple) and end (red) colors
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Red);

            // Save the presentation
            string outPath = "GradientShape.pptx";
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}