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

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Set fill to solid accent color
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

            // Retrieve effective fill format
            Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

            // Output effective fill type and color
            Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);
            if (effectiveFill.FillType == Aspose.Slides.FillType.Solid)
            {
                Console.WriteLine("Effective Fill Color: " + effectiveFill.SolidFillColor);
            }

            // Save the presentation
            presentation.Save("EffectiveFillFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}