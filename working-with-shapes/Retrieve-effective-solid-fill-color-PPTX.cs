using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape.FillFormat != null)
                        {
                            Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();
                            if (effectiveFill.FillType == Aspose.Slides.FillType.Solid)
                            {
                                Console.WriteLine("Slide {0}, Shape {1}: Solid Fill Color = {2}",
                                    slideIndex + 1, shapeIndex + 1, effectiveFill.SolidFillColor);
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}