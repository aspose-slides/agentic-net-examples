// -----------------------------------------------------------------------------
// Example: Add Bent Connector Between First Two Shapes on Each Slide
//
// Description:
// Demonstrates how to add a bent connector between the first two shapes on
// every slide of a PowerPoint presentation using Aspose.Slides for .NET.
// The program creates a sample PPTX if none exists, connects shapes, and
// saves the modified file. Useful for automated slide layout enhancements.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bent connector, shape linking
//
// Use Cases:
// - Automatically connect the first two shapes on each slide.
// - Build tools that modify PPTX files programmatically.
// - Enhance slide layouts before distribution.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace BentConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IShape sampleShape1 = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 100f, 50f);
                    Aspose.Slides.IShape sampleShape2 = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300f, 150f, 100f, 50f);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                    // Ensure there are at least two shapes to connect
                    if (shapes.Count >= 2)
                    {
                        Aspose.Slides.IShape firstShape = shapes[0];
                        Aspose.Slides.IShape secondShape = shapes[1];

                        // Add a bent connector
                        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0f, 0f, 10f, 10f);

                        // Connect the first two shapes
                        connector.StartShapeConnectedTo = firstShape;
                        connector.EndShapeConnectedTo = secondShape;

                        // Reroute to get the shortest path
                        connector.Reroute();
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
                Environment.Exit(0);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
