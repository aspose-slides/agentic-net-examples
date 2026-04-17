using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }
        string outputPath = "output.pptx";

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Slide slide = (Aspose.Slides.Slide)pres.Slides[0];

            double totalAngle = 0.0;
            int connectorCount = 0;

            // Iterate through shapes on the slide
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.Shape shape = (Aspose.Slides.Shape)slide.Shapes[i];
                if (shape is Aspose.Slides.AutoShape)
                {
                    Aspose.Slides.AutoShape autoShape = (Aspose.Slides.AutoShape)shape;
                    if (autoShape.ShapeType == Aspose.Slides.ShapeType.Line)
                    {
                        double angle = GetDirection(autoShape.Width, autoShape.Height,
                            Convert.ToBoolean(autoShape.Frame.FlipH), Convert.ToBoolean(autoShape.Frame.FlipV));
                        totalAngle += angle;
                        connectorCount++;
                    }
                }
                else if (shape is Aspose.Slides.Connector)
                {
                    Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;
                    double angle = GetDirection(connector.Width, connector.Height,
                        Convert.ToBoolean(connector.Frame.FlipH), Convert.ToBoolean(connector.Frame.FlipV));
                    totalAngle += angle;
                    connectorCount++;
                }
            }

            // Calculate and log average angle
            if (connectorCount > 0)
            {
                double averageAngle = totalAngle / connectorCount;
                Console.WriteLine("Average connector angle: " + averageAngle);
            }
            else
            {
                Console.WriteLine("No connectors found on the slide.");
            }

            // Save presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
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

    // Helper method to calculate direction angle of a shape
    static double GetDirection(double width, double height, bool flipH, bool flipV)
    {
        double w = flipH ? -width : width;
        double h = flipV ? -height : height;
        double radians = Math.Atan2(h, w);
        double degrees = radians * (180.0 / Math.PI);
        if (degrees < 0) degrees += 360;
        return degrees;
    }
}