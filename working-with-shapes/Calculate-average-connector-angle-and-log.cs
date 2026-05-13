using System;
using System.IO;
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
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("No slides in presentation.");
                }
                else
                {
                    Slide slide = (Slide)pres.Slides[0];
                    double totalAngle = 0.0;
                    int connectorCount = 0;

                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        Shape shape = (Shape)slide.Shapes[i];
                        if (shape is Connector)
                        {
                            Connector connector = (Connector)shape;
                            double angle = GetDirection(connector.Width, connector.Height,
                                Convert.ToBoolean(connector.Frame.FlipH),
                                Convert.ToBoolean(connector.Frame.FlipV));
                            totalAngle += angle;
                            connectorCount++;
                        }
                    }

                    if (connectorCount > 0)
                    {
                        double averageAngle = totalAngle / connectorCount;
                        Console.WriteLine("Average connector angle: " + averageAngle);
                    }
                    else
                    {
                        Console.WriteLine("No connectors found on the slide.");
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static double GetDirection(double width, double height, bool flipH, bool flipV)
    {
        double angle = Math.Atan2(height, width) * (180.0 / Math.PI);
        if (flipH)
        {
            angle = 180.0 - angle;
        }
        if (flipV)
        {
            angle = -angle;
        }
        return angle;
    }
}