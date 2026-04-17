using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                    shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;
                    shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
                    shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}