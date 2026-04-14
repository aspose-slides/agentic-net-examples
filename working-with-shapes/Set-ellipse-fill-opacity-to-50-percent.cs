using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
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
            using (Presentation pres = new Presentation(inputPath))
            {
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.ShapeType == ShapeType.Ellipse)
                        {
                            IFillFormat fill = autoShape.FillFormat;
                            if (fill != null && fill.FillType == FillType.Solid)
                            {
                                Color original = fill.SolidFillColor.Color;
                                Color withOpacity = Color.FromArgb(128, original);
                                fill.SolidFillColor.Color = withOpacity;
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}