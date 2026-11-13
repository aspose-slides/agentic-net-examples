// -----------------------------------------------------------------------------
// Example: Log shape fill type and line color in PPTX using Aspose.Slides
//
// Description:
// Demonstrates how to create a sample PPTX if missing, iterate through all
// shapes, log each shape's fill type and solid line color, and save the
// presentation. Uses Aspose.Slides for .NET in a C# console application.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape fill type, line color, logging
//
// Use Cases:
// - Automate validation of shape formatting in presentations.
// - Generate reports of visual properties for compliance checks.
// - Integrate shape property extraction into .NET PowerPoint processing tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                sampleShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                sampleShape.FillFormat.SolidFillColor.Color = Color.Blue;
                sampleShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                sampleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                Environment.Exit(1);
            }
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // format not supported
            Environment.Exit(1);
        }

        try
        {
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];
                    Aspose.Slides.FillType fillType = Aspose.Slides.FillType.NotDefined;
                    if (shape.FillFormat != null)
                    {
                        fillType = shape.FillFormat.FillType;
                    }

                    Color lineColor = Color.Empty;
                    if (shape.LineFormat != null && shape.LineFormat.FillFormat != null && shape.LineFormat.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                    {
                        lineColor = shape.LineFormat.FillFormat.SolidFillColor.Color;
                    }

                    Console.WriteLine("Slide {0}, Shape {1}: FillType = {2}, LineColor = {3}", i + 1, j + 1, fillType, lineColor.IsEmpty ? "None" : lineColor.Name);
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
            Environment.Exit(1);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
