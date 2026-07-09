using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                ISlide slide = pres.Slides[0];
                IShape shape = slide.Shapes[0];

                // Get effective line format data
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                // Get effective line fill format
                ILineFillFormatEffectiveData lineFill = effectiveLine.FillFormat;

                if (lineFill.FillType == FillType.Gradient)
                {
                    IGradientFormatEffectiveData gradient = lineFill.GradientFormat;
                    IGradientStopCollectionEffectiveData stops = gradient.GradientStops;

                    foreach (IGradientStopEffectiveData stop in stops)
                    {
                        Console.WriteLine("Gradient Stop - Position: " + stop.Position + ", Color: " + stop.Color);
                    }
                }
                else
                {
                    Console.WriteLine("The line shape does not use a gradient fill.");
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}