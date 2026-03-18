using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide and first shape
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Get effective fill formatting
            Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

            // Get effective line formatting
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

            // Get effective effect formatting (for shadow)
            Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();

            // Output effective fill information
            Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);
            if (effectiveFill.FillType == Aspose.Slides.FillType.Solid)
            {
                Console.WriteLine("Fill Color: " + effectiveFill.SolidFillColor);
            }

            // Output effective line information
            Console.WriteLine("Effective Line Style: " + effectiveLine.Style);
            Console.WriteLine("Effective Line Width: " + effectiveLine.Width);
            Console.WriteLine("Effective Line Fill Type: " + effectiveLine.FillFormat.FillType);
            if (effectiveLine.FillFormat.FillType == Aspose.Slides.FillType.Solid)
            {
                Console.WriteLine("Line Fill Color: " + effectiveLine.FillFormat.SolidFillColor);
            }

            // Output effective outer shadow information
            if (effectiveEffect.OuterShadowEffect != null)
            {
                Console.WriteLine("Outer Shadow Color: " + effectiveEffect.OuterShadowEffect.ShadowColor);
            }
            else
            {
                Console.WriteLine("No outer shadow effect.");
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}