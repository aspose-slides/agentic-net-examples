// -----------------------------------------------------------------------------
// Example: Calculate average connector angle and log using C#
//
// Description:
// Demonstrates how to calculate the average angle of connector shapes on the
// first slide of a PowerPoint presentation and log the result using C# and
// Aspose.Slides for .NET. The example loads an existing PPTX file, iterates
// through shapes to identify connectors, computes each connector's direction
// angle, determines the average, outputs it to the console, and saves the
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Calculate, Average, Connector,
// Angle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate calculation of average connector angles in presentations.
// - Build C# utilities for analyzing slide geometry.
// - Generate reports or logs for PowerPoint content validation.
// - Integrate connector angle analysis into .NET automation workflows.
// -----------------------------------------------------------------------------

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
