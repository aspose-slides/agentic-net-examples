using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAngleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (var pres = new Presentation(inputPath))
                {
                    var slide = pres.Slides[0];
                    var angles = new List<double>();

                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        var shape = slide.Shapes[i];

                        if (shape is AutoShape autoShape && autoShape.ShapeType == ShapeType.Line)
                        {
                            var angle = GetDirection(autoShape.Width, autoShape.Height,
                                Convert.ToBoolean(autoShape.Frame.FlipH),
                                Convert.ToBoolean(autoShape.Frame.FlipV));
                            angles.Add(angle);
                        }
                        else if (shape is Connector connector)
                        {
                            var angle = GetDirection(connector.Width, connector.Height,
                                Convert.ToBoolean(connector.Frame.FlipH),
                                Convert.ToBoolean(connector.Frame.FlipV));
                            angles.Add(angle);
                        }
                    }

                    if (angles.Count > 0)
                    {
                        var sum = 0.0;
                        foreach (var a in angles) sum += a;
                        var average = sum / angles.Count;
                        Console.WriteLine($"Average connector angle: {average} degrees");
                    }
                    else
                    {
                        Console.WriteLine("No connectors or line shapes found on the slide.");
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error processing presentation: {ex.Message}");
            }
        }

        private static double GetDirection(double width, double height, bool flipH, bool flipV)
        {
            var angle = Math.Atan2(height, width) * 180.0 / Math.PI;
            if (flipH) angle = 180.0 - angle;
            if (flipV) angle = -angle;
            return angle;
        }
    }
}