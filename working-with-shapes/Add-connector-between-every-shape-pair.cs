// -----------------------------------------------------------------------------
// Example: Add bent connectors between every shape pair in a PowerPoint presentation
//
// Description:
// Demonstrates how to programmatically add a bent connector between each pair of
// shapes on every slide of a PPTX file using Aspose.Slides for .NET. The code
// creates a sample input file if none exists, connects shape pairs, reroutes
// connectors, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, connector, shape pair, diagram automation
//
// Use Cases:
// - Automate diagram enrichment by linking all shapes in a slide.
// - Generate visual relationship maps in presentations programmatically.
// - Validate and visualize shape connections before publishing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a sample presentation with a few shapes
                using (Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                    firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 150, 80);
                    firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 150, 120, 120);
                    firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 200, 300, 100, 100);
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                    int shapeCount = shapes.Count;

                    for (int i = 0; i < shapeCount; i++)
                    {
                        for (int j = i + 1; j < shapeCount; j++)
                        {
                            Aspose.Slides.IShape shape1 = shapes[i];
                            Aspose.Slides.IShape shape2 = shapes[j];

                            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
                            connector.StartShapeConnectedTo = shape1;
                            connector.EndShapeConnectedTo = shape2;
                            connector.Reroute();
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation processed successfully. Output saved to " + outputPath);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
