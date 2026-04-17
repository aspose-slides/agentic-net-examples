using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();
        // Access the first slide
        ISlide slide = presentation.Slides[0];
        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
        // Set the line join style to Miter
        line.LineFormat.JoinStyle = LineJoinStyle.Miter;
        // Optionally set line width
        line.LineFormat.Width = 5;
        // Retrieve effective line format data
        ILineFormatEffectiveData effectiveData = line.LineFormat.GetEffective();
        // Verify the miter limit
        float miterLimit = effectiveData.MiterLimit;
        Console.WriteLine("Miter Limit: " + miterLimit);
        // Save the presentation
        try
        {
            presentation.Save("LineJoinMiter.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}