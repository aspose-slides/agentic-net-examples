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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Set fill type to gradient
            rectangle.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

            // Configure gradient direction from top-left to bottom-right
            rectangle.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1;
            rectangle.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Rectangle;

            // Add gradient stops (red at start, blue at end)
            rectangle.FillFormat.GradientFormat.GradientStops.Add(0.0f, System.Drawing.Color.Red);
            rectangle.FillFormat.GradientFormat.GradientStops.Add(1.0f, System.Drawing.Color.Blue);

            // Verify gradient stops by reading effective data
            Aspose.Slides.IFillFormatEffectiveData effectiveFill = rectangle.FillFormat.GetEffective();
            Aspose.Slides.IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;
            Console.WriteLine("First gradient stop color: " + effectiveGradient.GradientStops[0].Color.ToString());
            Console.WriteLine("Last gradient stop color: " + effectiveGradient.GradientStops[effectiveGradient.GradientStops.Count - 1].Color.ToString());

            // Save the presentation
            presentation.Save("DiagonalGradientRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing input file (if any)
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (System.Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            // format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}