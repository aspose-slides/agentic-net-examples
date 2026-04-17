using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rect = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Increase the corner radius by 5 points if the shape supports CornerSize adjustment
        if (rect.Adjustments.Count > 0 && rect.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.CornerSize)
        {
            rect.Adjustments[0].AngleValue += 5;
        }

        // Save the presentation
        pres.Save("RoundedRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}