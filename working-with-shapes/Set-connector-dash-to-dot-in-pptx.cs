// -----------------------------------------------------------------------------
// Example: Set connector dash style to dot in PPTX using C#
// 
// Description:
// Demonstrates how to set the line dash style of connector shapes to dot in a PowerPoint PPTX file using Aspose.Slides for .NET. The program creates a sample presentation if none exists, modifies connector dash styles, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, connector, dash style, dot
// 
// Use Cases:
// - Automate styling of connectors in presentations.
// - Build tools for batch processing of PPTX files.
// - Ensure visual consistency of diagram lines in generated slides.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);
                lineShape.LineFormat.Width = 2;
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                return 1;
            }
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.IShapeCollection shapes = presentation.Slides[slideIndex].Shapes;
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];
                        if (shape.LineFormat != null)
                        {
                            shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dot;
                        }
                    }
                }
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
            return 1;
        }

        Console.WriteLine("Connector dash style set to dot and saved to " + outputPath);
        return 0;
    }
}
