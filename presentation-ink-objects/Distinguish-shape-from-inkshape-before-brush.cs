using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

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
            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        Ink inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            IInkTrace[] traces = inkShape.Traces;
                            if (traces != null && traces.Length > 0)
                            {
                                IInkBrush brush = traces[0].Brush;
                                brush.Color = Color.Red;
                            }
                        }
                        else
                        {
                            if (shape.FillFormat != null)
                            {
                                shape.FillFormat.FillType = FillType.Solid;
                                shape.FillFormat.SolidFillColor.Color = Color.Blue;
                            }
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}